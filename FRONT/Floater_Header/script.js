window.addEventListener("scroll", function () {
    if (pageYOffset > 0) {
        document.querySelector(".header").classList.add("is_scroll");
    } else {
        document.querySelector(".header").classList.remove("is_scroll");
    }
});
