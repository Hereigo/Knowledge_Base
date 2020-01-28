document.addEventListener('DOMContentLoaded', function () {

    const cardBtn = document.getElementById('cart');
    const cart = document.querySelector('.cart');
    const goodsWrapper = document.querySelector('.goods-wrapper');
    const search = document.querySelector('.search');
    const searchBtn = document.getElementById('wishlist');

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

    const openCart = (event) => {

        // force prevent reference click action :
        event.preventDefault();

        cart.style.display = 'flex';
        document.addEventListener('keyup', closeCart);
    }

    const closeCart = (event) => {

        const target = event.target;

        // on Esc key , on Cart click , on cart-close Cross sign :
        if (event.keyCode === 27 || target === cart || target.classList.contains('cart-close')) {
            cart.style.display = '';
            document.removeEventListener('keyup', closeCart);
        }
    }

    cardBtn.addEventListener('click', openCart);
    cart.addEventListener('click', closeCart);







    //
    // END of
    // document.addEventListener('DOMContentLoaded', function() {
});