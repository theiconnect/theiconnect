// Dept code: D-001, D-002, ... (persisted sequence).
// Dept name defaults to "HR", editable but restricted to letters and spaces.
// Back and Save confirmations. Save posts to /api/departments, falls back to localStorage.

document.addEventListener("DOMContentLoaded", () => {
    const deptCodeEl = document.getElementById("deptCode");
    const deptNameEl = document.getElementById("deptName");
    const deptLocationEl = document.getElementById("deptLocation");
    const btnBack = document.getElementById("btnBack");
    const btnSave = document.getElementById("btnSave");
    const statusMessage = document.getElementById("statusMessage");
    const deptNameHint = document.getElementById("deptNameHint");

    const modal = document.getElementById("confirmModal");
    const modalTitle = document.getElementById("confirmTitle");
    const modalMessage = document.getElementById("confirmMessage");
    const modalOk = document.getElementById("confirmOk");
    const modalCancel = document.getElementById("confirmCancel");

    const SEQ_KEY = "dept_last_seq";

    function readLastSeq() {
        const v = parseInt(localStorage.getItem(SEQ_KEY) || "0", 10);
        return Number.isFinite(v) ? v : 0;
    }

    function writeLastSeq(n) {
        localStorage.setItem(SEQ_KEY, String(n));
    }

    function formatDeptCode(n) {
        return `D-${String(n).padStart(3, "0")}`;
    }

    function generateDeptCode() {
        const next = readLastSeq() + 1;
        writeLastSeq(next);
        return formatDeptCode(next);
    }

    // initialize
    deptCodeEl.value = generateDeptCode();
    // deptName default is set in HTML to "HR"

    // Validation regex: letters and spaces only
    const allowedCharRegex = /^[A-Za-z\s]$/;
    const fullValidateRegex = /^[A-Za-z\s]+$/;

    // Prevent invalid keystrokes (numbers, operators, special chars)
    deptNameEl.addEventListener("beforeinput", (e) => {
        const ch = e.data;

        // Ignore non-character events (backspace, delete, arrow keys)
        if (!ch) return;

        // Allow ONLY A–Z and spaces
        if (!/^[A-Za-z\s]$/.test(ch)) {
            e.preventDefault();
            flashHintError("Only letters and spaces are allowed.");
        }
    });

    // Sanitize input (covers paste, IME, drag-drop)
    deptNameEl.addEventListener("input", () => {
        const before = deptNameEl.value;
        const sanitized = before.replace(/[^A-Za-z\s]/g, "");
        if (before !== sanitized) {
            deptNameEl.value = sanitized;
            flashHintError("Removed invalid characters.");
        }
        clearValidationStyles();
    });

    // Handle paste explicitly to sanitize
    deptNameEl.addEventListener("paste", (e) => {
        e.preventDefault();
        const text = (e.clipboardData || window.clipboardData).getData("text") || "";
        const sanitized = text.replace(/[^A-Za-z\s]/g, "");
        const start = deptNameEl.selectionStart || 0;
        const end = deptNameEl.selectionEnd || 0;
        const newVal = deptNameEl.value.slice(0, start) + sanitized + deptNameEl.value.slice(end);
        deptNameEl.value = newVal;
        const pos = start + sanitized.length;
        deptNameEl.setSelectionRange(pos, pos);
        clearValidationStyles();
    });

    function flashHintError(msg) {
        deptNameHint.textContent = msg;
        deptNameHint.classList.add("hint-error");
        deptNameEl.classList.add("input-error");
        setTimeout(() => {
            deptNameHint.textContent = "Use letters and spaces only (no numbers or special characters).";
            deptNameHint.classList.remove("hint-error");
            deptNameEl.classList.remove("input-error");
        }, 1500);
    }

    function clearValidationStyles() {
        deptNameHint.classList.remove("hint-error");
        deptNameEl.classList.remove("input-error");
    }

    // Generic modal helper - sets button labels and callbacks each time
    function showModal(title, message, okText = "OK", cancelText = "Cancel", okCallback = null, cancelCallback = null) {
        modalTitle.textContent = title;
        modalMessage.textContent = message;
        modalOk.textContent = okText;
        modalCancel.textContent = cancelText;

        // remove prior handlers
        modalOk.onclick = null;
        modalCancel.onclick = null;

        modalOk.onclick = () => {
            closeModal();
            if (typeof okCallback === "function") okCallback();
        };
        modalCancel.onclick = () => {
            closeModal();
            if (typeof cancelCallback === "function") cancelCallback();
        };

        modal.classList.remove("hidden");
        modalOk.focus();
    }

    function closeModal() {
        modal.classList.add("hidden");
    }

    // Back button -> confirm (OK / Cancel)
    btnBack.addEventListener("click", () => {
        showModal(
            "Confirm navigation",
            "Are you sure you want to go back?",
            "OK",
            "Cancel",
            () => {
                if (history.length > 1) history.back();
                else window.location.href = "/";
            },
            () => {
                // do nothing (stay on page)
            }
        );
    });

    // Save button -> confirm (OK / Exit)
    btnSave.addEventListener("click", () => {
        showModal(
            "Confirm save",
            "Are you sure you want to save the data?",
            "OK",
            "Exit",
            async () => {
                const name = (deptNameEl.value || "").trim();
                const location = deptLocationEl.value;

                if (!name) {
                    showStatus("Department Name is required.", "var(--danger)");
                    deptNameEl.classList.add("input-error");
                    deptNameEl.focus();
                    return;
                }
                if (!fullValidateRegex.test(name)) {
                    showStatus("Department Name can contain letters and spaces only.", "var(--danger)");
                    deptNameEl.classList.add("input-error");
                    deptNameEl.focus();
                    return;
                }
                if (!location) {
                    showStatus("Please select a Department Location.", "var(--danger)");
                    deptLocationEl.focus();
                    return;
                }

                const payload = {
                    deptCode: deptCodeEl.value,
                    deptName: name,
                    deptLocation: location
                };

                showStatus("Saving...", "var(--muted)");

                try {
                    const res = await fetch("/api/departments", {
                        method: "POST",
                        headers: { "Content-Type": "application/json" },
                        body: JSON.stringify(payload)
                    });

                    if (res.ok) {
                        showStatus("Saved successfully.", "var(--success)");
                        // prepare next sequential code and reset form to default state
                        deptCodeEl.value = generateDeptCode();
                        deptNameEl.value = "HR";
                        deptLocationEl.value = "";
                    } else {
                        // server error fallback
                        saveLocally(payload);
                        showStatus("Saved locally (server error).", "orange");
                        deptCodeEl.value = generateDeptCode();
                        deptNameEl.value = "HR";
                        deptLocationEl.value = "";
                    }
                } catch (err) {
                    console.warn("Save failed, storing locally:", err);
                    saveLocally(payload);
                    showStatus("Saved locally (no server).", "orange");
                    deptCodeEl.value = generateDeptCode();
                    deptNameEl.value = "HR";
                    deptLocationEl.value = "";
                }
            },
            () => {
                // Exit: close modal and remain on page
            }
        );
    });

    // close modal with Escape
    window.addEventListener("keydown", (e) => {
        if (e.key === "Escape" && !modal.classList.contains("hidden")) {
            closeModal();
        }
    });

    function showStatus(text, color) {
        statusMessage.textContent = text;
        statusMessage.style.color = color || "";
    }

    function saveLocally(payload) {
        const pending = JSON.parse(localStorage.getItem("pendingDepartments") || "[]");
        pending.push(Object.assign({ savedAt: new Date().toISOString() }, payload));
        localStorage.setItem("pendingDepartments", JSON.stringify(pending));
    }
});