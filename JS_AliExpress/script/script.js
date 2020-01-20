document.addEventListener('DOMContentLoaded', function () {

    // const search = document.querySelectorAll('.search');  
    const search = document.querySelector('.search');
    console.dir(search); // view as object ;

    const cardBtn = document.getElementById('#card');
    const searcgBtn = document.getElementById('#wishlist');

    const goodsWrapper = document.querySelector('.goods-wrapper');

    // this function does NOT available until line 13 !
    const createCardGoods = function () {
        const card = document.createElement('div');
        card.className = 'card-wrapper col-12 col-md-6 col-lg-4 col-xl-3 pb-3';
        card.innerHTML = `<div class="card">
                            <div class="card-img-wrapper">
                                <img class="card-img-top" src="img/temp.png" alt="">
                                <button class="card-add-wishlist"></button>
                            </div>
                            <div class="card-body justify-content-between">
                                <a href="#" class="card-title">Имя товара</a>
                                <div class="card-price">100000 ₽</div>
                                <div>
                                    <button class="card-add-cart">Добавить в корзину</button>
                                </div>
                            </div>
                        </div>`;
        return card;
    };

    goodsWrapper.appendChild(createCardGoods());
    goodsWrapper.appendChild(createCardGoods());
    goodsWrapper.appendChild(createCardGoods());
    goodsWrapper.appendChild(createCardGoods());

    // PAUSED ON PART 1 TIME 1:17:00
    // PAUSED ON PART 1 TIME 1:17:00
    // PAUSED ON PART 1 TIME 1:17:00




    //
    //
    // END document.addEventListener('DOMContentLoaded', function() {
});