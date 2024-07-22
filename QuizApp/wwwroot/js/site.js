// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', (event) => {

    // Load the saved radio button value from localStorage
    for (let i = 0; i < localStorage.length; i++) {

        const savedOption = localStorage.getItem(localStorage.key(i));
        let sub = localStorage.key(i).split("_");
       
        if (document.querySelector(`input[type="radio"][id="${sub[0]}_${savedOption}_${sub[1]}"]`) !== null) {
            if (savedOption) {
                document.querySelector(`input[type="radio"][id="${sub[0]}_${savedOption}_${sub[1]}"]`).checked = true;
            }
        }
    }
   

        // Save the selected radio button value to localStorage when changed
        document.querySelectorAll('input[type="radio"]').forEach(radio => {
            
            let str = radio.id.split("_");
            let newStr = str[0] + "_" + str[2];

            radio.addEventListener('change', () => {
                
                localStorage.setItem(newStr, radio.value);
                

            });
        });
    
});