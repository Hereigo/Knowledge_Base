$(document).ready(function () {

    $.post("/Home/GetAvailability/", function (data) {

        let availabilityData = JSON.parse(data);

        availabilityData.forEach(function (item) {

            let availability = document.querySelector('#' + item.Key);

            availability.innerHTML = item.Value;
        });
    });

    //document.querySelector("#sortby").onchange = function () {
    //    var index = this.selectedIndex;
    //    var inputText = this.children[index].innerHTML.trim();
    //    console.log(inputText);
    //}
});