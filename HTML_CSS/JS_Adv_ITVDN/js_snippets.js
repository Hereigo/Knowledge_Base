document.addEventListener("DOMContentLoaded", function () {

	// TEST :
	const firstForm = document.forms[0];
	firstForm.addEventListener('change', function (event) {
        const target = event.target
        if (target.matches('input')) {
            alert(target.value)
        }
    });

    // TEXT COPY PREVENTED :
    document.querySelector('#nocopy').addEventListener('copy', (e) => {
        alert('You can not copy!');
        e.preventDefault();
    });

    // REPLACE CONTEXTMENU FOR R.B.C. :
    document.querySelector('#rbc-loc').addEventListener('contextmenu', (e) => {
        alert('Click');
        console.log(e);
        e.preventDefault();
    });

    // REPLACE CONTEXTMENU FOR R.B.C. WITH CUSTOM MENU :
    let menuDisplayed = false;
    let menuBox = null;
    let contextMenu = document.querySelector("#rbc-custom");

    contextMenu.addEventListener("contextmenu", (ev) => {
        let left = ev.clientX;
        let top = ev.clientY;
        menuBox = document.querySelector("#my-ctx-menu");
        menuBox.style.left = left + "px";
        menuBox.style.top = top + "px";
        menuBox.style.display = "block";
        ev.preventDefault();
        menuDisplayed = true;
    });

    window.addEventListener("click", (e) => {
        if (menuDisplayed == true) {
            menuBox.style.display = 'none';
        }
    });

    // HANDLING SCROLL OVER THE CONTAINER :
    let elem = document.querySelector('#my-scroll-container');

    // check if 'onwheel' exists in browser
    if (elem.addEventListener) {
        if ('onwheel' in document) {
            // IE9+, FF17+, Ch31+
            elem.addEventListener('wheel', onWheel);
        } else if ('onmousewheel' in document) {
            elem.addEventListener('mousewheel', onWheel);
        } else { // Firefox < 17
            elem.addEventListener('MozMousePixelScroll', onWheel);
        }
    } else { // IE8-
        elem.attachEvent('onmousewheel', onWheel);
    }

    function onWheel(e) {
        console.log(e);
        let delta = e.deltaY;
        let info = document.getElementById('delta');
        info.innerHTML = +info.innerHTML + delta;
    };

    // HANDLING SCROLL AND ZOOMING TEXT :
    let scale = 1;

    function addOnWheel(elem, handler) {
        elem.addEventListener('wheel', handler);
    }

    addOnWheel(text, (e) => {
        if (e.deltaY > 0) scale += 0.05;
        else scale -= 0.05;

        text.style.transform = 'scale(' + scale + ')';

        e.preventDefault();
    });


    // END of document.addEventListener("DOMContentLoaded", function () {
});