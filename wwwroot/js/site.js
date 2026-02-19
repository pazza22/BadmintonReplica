// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Night Mode Toggle Functionality
(function() {
    const nightModeToggle = document.getElementById('nightModeToggle');
    const body = document.body;
    const moonIcon = 'fa-moon';
    const sunIcon = 'fa-sun';
    
    // Check for saved theme preference or default to light mode
    const currentTheme = localStorage.getItem('theme') || 'light';
    
    // Apply saved theme on page load
    if (currentTheme === 'dark') {
        body.classList.add('dark-mode');
        if (nightModeToggle) {
            const icon = nightModeToggle.querySelector('i');
            if (icon) {
                icon.classList.remove(moonIcon);
                icon.classList.add(sunIcon);
            }
        }
    }
    
    // Toggle night mode on button click
    if (nightModeToggle) {
        nightModeToggle.addEventListener('click', function() {
            body.classList.toggle('dark-mode');
            const icon = this.querySelector('i');
            
            if (body.classList.contains('dark-mode')) {
                // Switch to dark mode
                localStorage.setItem('theme', 'dark');
                if (icon) {
                    icon.classList.remove(moonIcon);
                    icon.classList.add(sunIcon);
                }
            } else {
                // Switch to light mode
                localStorage.setItem('theme', 'light');
                if (icon) {
                    icon.classList.remove(sunIcon);
                    icon.classList.add(moonIcon);
                }
            }
        });
    }
})();
