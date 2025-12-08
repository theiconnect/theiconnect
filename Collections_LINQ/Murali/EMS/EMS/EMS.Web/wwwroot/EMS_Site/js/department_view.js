// --- Helper Functions for Auto-Generation ---

// 1. Function to generate a simple sequential ID (e.g., 101, 102)
function generateDeptId() {
    // In a real system, this would come from the database.
    // Here we use localStorage for persistence across page loads.
    let lastId = parseInt(localStorage.getItem('lastDeptId')) || 100;
    lastId++;
    localStorage.setItem('lastDeptId', lastId);
    return lastId;
}

// 2. Function to generate the code prefix (e.g., 'Human Resources' -> 'HR')
function getCodePrefix(deptName) {
    if (!deptName) return "DPT";

    // Split, take the first letter of each word (max 2), and make uppercase
    const words = deptName.split(/\s+/).slice(0, 2);
    let prefix = words.map(word => word.charAt(0)).join('').toUpperCase();

    if (prefix.length < 2) {
        // Fallback for single-word names (e.g., "IT" remains "IT")
        return deptName.substring(0, 2).toUpperCase();
    }
    return prefix;
}

// 3. Function to get the sequential number for the code (e.g., 001)
function getNextCodeNumber(prefix) {
    // We use a specific key for each prefix to ensure unique numbering (HR001, IT001)
    const storageKey = `lastDeptCodeNum_${prefix}`;
    let lastCodeNum = parseInt(localStorage.getItem(storageKey)) || 0;

    // NOTE: For a "View" page, we assume the code is already generated.
    // For this example, we'll return the current count and increment it.
    lastCodeNum++;
    localStorage.setItem(storageKey, lastCodeNum);
    return lastCodeNum;
}

// 4. Main function to update both ID and Code
function updateDepartmentFields(initialLoad = true) {
    const deptNameSelect = document.getElementById('deptName');
    const deptIdInput = document.getElementById('deptId');
    const deptCodeInput = document.getElementById('deptCode');

    // --- Generate ID ---
    // In a view page, ID and Code are typically loaded from data. 
    // We simulate generation for the purpose of this exercise.
    if (initialLoad) {
        deptIdInput.value = generateDeptId();
    }

    // --- Generate Code (based on selected Name) ---
    const selectedName = deptNameSelect.value;
    const prefix = getCodePrefix(selectedName);

    // For a view/new page, you'd want to generate the NEXT code.
    // We use a fixed number (1) for this view demonstration, 
    // as a 'view' implies displaying existing data.
    // If this were a new entry, we'd use getNextCodeNumber(prefix).

    // SIMULATION: Displaying the existing (or next) code for the selected department
    const simulatedCodeNumber = 1;
    deptCodeInput.value = prefix ? `${prefix}${String(simulatedCodeNumber).padStart(3, '0')}` : "[Select Name]";
}


// --- Main Script Execution ---
document.addEventListener('DOMContentLoaded', () => {
    const deptNameSelect = document.getElementById('deptName');
    const goBackBtn = document.getElementById('goBackBtn');

    // Set initial values (Simulated data fetch)
    // We select a default department to showcase the code generation
    deptNameSelect.value = "Human Resources";
    updateDepartmentFields(true);

    // Update code when department name changes
    deptNameSelect.addEventListener('change', () => {
        updateDepartmentFields(false); // Do not generate a new ID on name change
    });


    // Go Back Button Functionality
    goBackBtn.addEventListener('click', () => {
        // window.confirm creates the native browser pop-up box (OK/Cancel)
        const isConfirmed = window.confirm("Are you sure you want to go back? You will leave this view.");

        if (isConfirmed) {
            // User clicked 'OK' -> Go back
            console.log("User confirmed. Navigating back...");
            // Standard method to go back:
            // window.history.back(); 
            alert("Simulating Go Back. You would now return to the previous list/dashboard page.");

        } else {
            // User clicked 'Cancel' -> Remain on the current page
            console.log("Navigation cancelled. Remaining on the Department View page.");
        }
    });
});