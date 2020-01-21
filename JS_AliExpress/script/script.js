document.addEventListener('DOMContentLoaded', function () {

    // const search = document.querySelectorAll('.search');  
    const search = document.querySelector('.search');
    // console.dir(search); // view as object ;

    const cart = document.querySelector('.cart');
    const cartClose = document.querySelector('.cart-close');
    const cardBtn = document.getElementById('cart');
    const searchBtn = document.getElementById('wishlist');

    const goodsWrapper = document.querySelector('.goods-wrapper');

    // this function does NOT available until line 13 !
    const createCardGoods = (id, title, price, img) => {
        const card = document.createElement('div');
        card.className = 'card-wrapper col-12 col-md-6 col-lg-4 col-xl-3 pb-3';
        card.innerHTML =
            `<div class="card">
                <div class="card-img-wrapper">
                    <img class="card-img-top" src="img/temp/${img}" alt="">
                    <button class="card-add-wishlist" data-goods-id="${id}"></button>
                </div>
                <div class="card-body justify-content-between">
                    <a href="#" class="card-title">${title}</a>
                    <div class="card-price">${price} ₴</div>
                    <div>
                        <button class="card-add-cart" data-goods-id="${id}">Добавить в корзину</button>
                    </div>
                </div>
            </div>`;
        return card;
    };

    goodsWrapper.appendChild(createCardGoods(111, 'Adfkj hd', 100000, 'Archer.jpg'));
    goodsWrapper.appendChild(createCardGoods(222, 'Dkldhb DIbh', 200000, 'Flamingo.jpg'));
    goodsWrapper.appendChild(createCardGoods(333, 'Dljbhuyobyuo', 300000, 'Socks.jpg'));

    const openCart = () => {
        cart.style.display = 'flex';
    }
    const closeCart = (event) => {
        cart.style.display = '';
    }

    cardBtn.addEventListener('click', openCart);
    cartClose.addEventListener('click', closeCart);



    // PAUSED ON PART 1 TIME 1:55:00




    //
    //
    // END document.addEventListener('DOMContentLoaded', function() {
});