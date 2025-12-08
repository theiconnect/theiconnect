// Beginner-friendly JS: toggle sidebar on small screens and simple active link handling

document.addEventListener('DOMContentLoaded', function () {
    var toggle = document.getElementById('sidebarToggle');
    var sidebar = document.getElementById('sidebar');
    var links = document.querySelectorAll('.nav-link');

    // Toggle sidebar for small screens
    if (toggle && sidebar) {
        toggle.addEventListener('click', function () {
            sidebar.classList.toggle('open');
        });
    }

    // Simple active-link logic: mark clicked item active
    links.forEach(function (link) {
        link.addEventListener('click', function () {
            links.forEach(function (l) { l.classList.remove('active'); });
            link.classList.add('active');

            // If sidebar is open on small screens, close it after clicking
            if (sidebar.classList.contains('open')) {
                sidebar.classList.remove('open');
            }
        });
    });
});