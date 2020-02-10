document.addEventListener('DOMContentLoaded', function () {

    const cardBtn = document.getElementById('cart');
    const cart = document.querySelector('.cart');
    const category = document.querySelector('.category');
    const goodsWrapper = document.querySelector('.goods-wrapper');
    const search = document.querySelector('.search');
    const searchBtn = document.getElementById('wishlist');

    const createCardGoods = (id, title, price, img) => {
        const card = document.createElement('div');
        card.className = 'card-wrapper col-12 col-md-6 col-lg-4 col-xl-3 pb-3';
        card.innerHTML =
            `<div class="card">
                <div class="card-img-wrapper">
                    <img class="card-img-top" src="${img}" alt="">
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

    const openCart = event => {
        // force prevent reference click action :
        event.preventDefault();
        cart.style.display = 'flex';
        document.addEventListener('keyup', closeCart);
    }

    const closeCart = event => {
        const target = event.target;
        // on Esc key , on Cart click , on cart-close Cross sign :
        if (event.keyCode === 27 || target === cart || target.classList.contains('cart-close')) {
            cart.style.display = '';
            document.removeEventListener('keyup', closeCart);
        }
    }

    const chooseCategory = event => {
        event.preventDefault();
        const target = event.target;
        if (target.classList.contains('category-item')) {
            const selectedCat = target.dataset.category;
            getGoods(renderCard,
                goods => goods.filter(item => item.category.includes(selectedCat)));
        }
    };

    cardBtn.addEventListener('click', openCart);
    cart.addEventListener('click', closeCart);
    category.addEventListener('click', chooseCategory);

    const renderCard = cardsArray => {
        // clear before re-render.
        goodsWrapper.textContent = '';
        cardsArray.forEach((arrayElem) => {
            const { id, title, price, imgMin } = arrayElem;
            goodsWrapper.appendChild(
                createCardGoods(id, title, price, imgMin)
            );
        });
    };

    const getGoods = (handler, filter) => {
        fetch('db/db.json')
            .then((rez) => { return rez.json(); })
            .then(filter)
            .then(handler);
    }

    const randomSort = (array) => array.sort(() => Math.random() - 0.5);

    getGoods(renderCard, randomSort);





    //
    // END of
    // document.addEventListener('DOMContentLoaded', function() {
});