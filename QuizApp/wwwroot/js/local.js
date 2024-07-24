document.addEventListener('DOMContentLoaded', (event) => {

    const routeId = document.getElementsByTagName("form")[0].id;
    if (!routeId) {
        console.error('"routeId" not found.');
        return;
    }

    const countdownMinutes = 3; 
    let endTime = localStorage.getItem(`time_${routeId}`);
    if (!endTime) {
        endTime = Date.now() + countdownMinutes * 60 * 1000; 
        localStorage.setItem(`time_${routeId}`, endTime);
    } else {
        endTime = parseInt(endTime, 10);
 
    }
    function updateCounter() {
     
        const now = Date.now();
        const remainingTime = endTime - now;

       
        const minutes = Math.floor((remainingTime / (1000 * 60)) % 60);
        const seconds = Math.floor((remainingTime / 1000) % 60);

        if (remainingTime <= 0) {
            document.getElementById('timer').textContent = '00:00';
            clearInterval(timerInterval);
            localStorage.removeItem(`time_${routeId}`); 
            localStorage.removeItem(routeId);
            document.querySelector('form').submit();
            return;
        }
 
        
        const formattedMinutes = String(minutes).padStart(2, '0');
        const formattedSeconds = String(seconds).padStart(2, '0');

        // Display the time
        document.getElementById('timer').textContent = `${formattedMinutes}:${formattedSeconds}`;
    }
    let checkmap = localStorage.getItem(routeId);
    if (!checkmap) {
      
      
        checkmap = JSON.stringify(Array.from(new Map()));

        localStorage.setItem(routeId, checkmap);
        

    }
    const timerInterval = setInterval(updateCounter, 1000);

    const map = new Map(JSON.parse(checkmap));

    for (const [key, value] of map) {
       

        if (document.querySelector(`input[type="radio"][id="${routeId}_${value}_${key}"]`) !== null) {
            if (value) {
                document.querySelector(`input[type="radio"][id="${routeId}_${value}_${key}"]`).checked = true;
            }
        }
    }

    document.querySelectorAll(`input[type="radio"][id^="${routeId}_"]`).forEach(radio => {

        let str = radio.id.split("_");





        radio.addEventListener('change', () => {
          
            const mapcon = JSON.parse(localStorage.getItem(routeId));
            const mapitem = new Map(mapcon);

            mapitem.set(str[2], radio.value);

            const mapArray = Array.from(mapitem);
            localStorage.setItem(routeId, JSON.stringify(mapArray));
          
        });
    });
    document.querySelector('form').addEventListener('submit', () => {
        localStorage.removeItem(routeId);
        clearInterval(timerInterval);
        localStorage.removeItem(`time_${routeId}`);
      
       
    });

});