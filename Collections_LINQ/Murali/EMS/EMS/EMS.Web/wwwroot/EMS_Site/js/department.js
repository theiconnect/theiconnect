// --- Helper Function for Auto Code Generation ---

/**
 * Generates a department code based on the department name.
 * Simulates a server-side sequencing process using localStorage.
 * @param {string} deptName The name of the department (e.g., "Human Resources").
 * @returns {string} The formatted department code (e.g., "HR001").
 */
function generateDeptCode(deptName) {
    if (!deptName) return "[Code Pending]";

    // 1. Generate Prefix (e.g., 'Human Resources' -> 'HR')
    const words = deptName.trim().split(/\s+/);
    let prefix = words.map(word => word.charAt(0)).join('').toUpperCase();

    // Ensure prefix is at least two characters long
    if (prefix.length < 2 && deptName.length >= 2) {
        prefix = deptName.substring(0, 2).toUpperCase();
    } else if (prefix.length < 2) {
        prefix = "DP";
    }

    // 2. Simulate Sequence Number
    // Use a unique key for each prefix to get the next number
    const storageKey = `lastDeptCodeNum_${prefix}`;
    // NOTE: On a *View* page, we often just display data.
    // Here, we simulate generating the NEXT code for a *New Entry*.
    let lastCodeNum = parseInt(localStorage.getItem(storageKey)) || 0;

    // Increment the number for the next entry
    lastCodeNum++;

    // 3. Update storage and format
    localStorage.setItem(storageKey, lastCodeNum);
    const paddedNum = String(lastCodeNum).padStart(3, '0');

    return prefix + paddedNum;
}


// --- Main Script Execution ---
document.addEventListener('DOMContentLoaded', () => {
    // Get required DOM elements
    const deptNameInput = document.getElementById('deptName');
    const deptCodeInput = document.getElementById('deptCode');
    const btnBack = document.getElementById('btnBack');
    const statusMessage = document.getElementById('statusMessage');

    // 1. Dynamic Code Generation based on Dept Name Input
    deptNameInput.addEventListener('input', () => {
        const name = deptNameInput.value.trim();
        if (name.length > 0) {
            // Display a temporary code suggestion while typing
            const tempPrefix = generateDeptCode(name).slice(0, -3); // Get prefix only
            deptCodeInput.value = `${tempPrefix}00X (Final code on Save)`;
        } else {
            deptCodeInput.value = "";
        }
    });

    // 2. GoBack Button Functionality with Confirmation Pop-up
    btnBack.addEventListener('click', () => {
        // window.confirm creates the native browser pop-up box (OK/Cancel)
        const isConfirmed = window.confirm("Are you sure you want to go back? Any unsaved data will be lost.");

        if (isConfirmed) {
            // User clicked 'OK' -> Go back to the previous page
            statusMessage.textContent = "Navigating back...";
            // window.history.back(); // Standard way to go back
            // Simulating the action:
            alert("Confirmed: Returning to the previous page.");

        } else {
            // User clicked 'Cancel' -> Remain on the current page
            statusMessage.textContent = "Navigation cancelled.";
            console.log("Navigation cancelled. Remaining on the current page.");
        }
    });

    // 3. Form Submission Handling (Simulating Save)
    // Even though you don't have a Save button, it's good practice to show how the code would finalize.
    deptForm.addEventListener('submit', (e) => {
        e.preventDefault();

        const name = deptNameInput.value.trim();
        if (!name) {
            statusMessage.textContent = "Error: Department Name is required.";
            return;
        }

        // Generate the final, unique code and save the new count
        const finalCode = generateDeptCode(name);
        deptCodeInput.value = finalCode; // Update the display with the final code

        const data = {
            code: finalCode,
            name: name,
            location: document.getElementById('deptLocation').value
        };

        // --- Save Simulation ---
        console.log("Data to be Saved:", data);
        statusMessage.textContent = `✅ Successfully created ${data.code} for ${data.name}.`;

        // Reset the form for a new entry (Optional)
        // deptForm.reset();
    });

    // Initialize the Dept Code placeholder on load
    deptNameInput.dispatchEvent(new Event('input'));
});