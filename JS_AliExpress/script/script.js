document.addEventListener('DOMContentLoaded', function () {

    const cardBtn = document.getElementById('cart');
    const cart = document.querySelector('.cart');
    const goodsWrapper = document.querySelector('.goods-wrapper');
    const search = document.querySelector('.search');
    const searchBtn = document.getElementById('wishlist');
    const category = document.querySelector('.category');

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

            // console.log(target.dataset);

            getGoods(renderCard, goods => {

                //console.log(goods);

                let filtered = [];

                goods.forEach(item => {
                    if (item.category == target.dataset.category)
                        filtered.push(item);
                });

                //console.log('AAA', filtered.length);

                return filtered;
            });
        }
    };

    cardBtn.addEventListener('click', openCart);
    cart.addEventListener('click', closeCart);
    category.addEventListener('click', chooseCategory);

    const getGoods = (handler, filter) => {
        fetch('db/db.json')
            .then((rez) => { return rez.json(); })
            .then(filter)
            .then(handler);
    }

    const renderCard = cardsArray => {
        cardsArray.forEach((arrayElem) => {
            const { id, title, price, imgMin } = arrayElem;
            goodsWrapper.appendChild(
                createCardGoods(id, title, price, imgMin)
            );
        });
    };

    const randomSort = (array) => array.sort(() => Math.random() - 0.5);

    getGoods(renderCard, randomSort);


    // ------------ 2:19:00 





    //
    // END of
    // document.addEventListener('DOMContentLoaded', function() {
});