// 1.
document.querySelector("p").innerText += " <b>New Text</b>"; // add tags as raw
document.querySelector("p").innerHTML += " <b>New Text</b>"; // add as html

// 2.
document.querySelector("h3").outerHTML = "<h1>New H1 Title</h1>"; // full replace with tags!
document.querySelector("h2").outerText = "<h1> New H1 Title !!!</h1>"; // full replace, but as raw text (NO FF !!!)

// 3. - insertAdjacentHTML(where, html);
document.querySelector("div").insertAdjacentHTML("beforeBegin", "111");
document.querySelector("div").insertAdjacentHTML("afterBegin", "222");
document.querySelector("div").insertAdjacentHTML("beforeEnd", "333");
document.querySelector("div").insertAdjacentHTML("afterEnd", "444");
// ["beforeBegin"] <div> ["afterBegin"] Some Text. ["beforeEnd"] </div> ["afterEnd"]

// 4. - Span INSIDE another tag with CLASS "a-parent" :
document.querySelector(".a-parent span").innerHTML = "TEXT CHANGED!";

// 5. - If TAG is not RAIRED - we use its ATTRIBUTES !
document.querySelector("img").src = "https://cdn3.iconfinder.com/data/icons/logos-brands-3/24/logo_brand_brands_logos_linux-48.png";

let checkedRadio = document.querySelector('.radios[checked]');
console.log(checkedRadio.id);

function radioChanged(elem){
    console.log(elem.id);
}