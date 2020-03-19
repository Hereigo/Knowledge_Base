document.addEventListener('DOMContentLoaded', function () {

  const cardBtn = document.getElementById('cart');
  const cart = document.querySelector('.cart');
  const category = document.querySelector('.category');
  const goodsWrapper = document.querySelector('.goods-wrapper');
  const search = document.querySelector('.search');
  const wishlistBtn = document.getElementById('wishlist');
  const cardCounter = cardBtn.querySelector('.counter');
  const wishlistCounter = wishlistBtn.querySelector('.counter');
  const shopCartWrapperElem = document.querySelector('.cart-wrapper');



  // PAUSED ON 2:34:00



  const checkCounter = () => {
    // wishlist counter :
    wishlistCounter.textContent = wishlist.length;
    // shoppingCart counter :
    cardCounter.textContent = Object.keys(goodsBasket).length; 
  };

  const storageQuery = (get) => {
    if (get) {
      if (localStorage.getItem('wishlist')) {
        JSON.parse(localStorage.getItem('wishlist')).forEach(id => wishlist.push(id));
      }
    } else {
      localStorage.setItem('wishlist', JSON.stringify(wishlist));
    }
    checkCounter();
  };

  const wishlist = []; //
  const goodsBasket = {};

  storageQuery(true);

  const showLoadingSpinner = () => {
    goodsWrapper.innerHTML = `<div id="spinner"><div class="spinner-loading"><div><div><div></div>
    </div><div><div></div></div><div><div></div></div><div><div></div></div></div></div></div>`;
  };

  const createCardGoods = (id, title, price, img) => {
    const card = document.createElement('div');
    card.className = 'card-wrapper col-12 col-md-6 col-lg-4 col-xl-3 pb-3';
    card.innerHTML =
      `<div class="card">
                <div class="card-img-wrapper">
                    <img class="card-img-top" src="${img}" alt="">
                    <button data-goods-id="${id}"
                      class="card-add-wishlist ${wishlist.includes(id) ? 'active' : ''}"> <!-- MARKED AS FAV AFTER REFRESH PAGE! -->
                    </button>
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

  const renderCard = cardsArray => {
    // clear before re-render.
    goodsWrapper.textContent = '';
    if (cardsArray.length) {
      cardsArray.forEach((arrayElem) => {
        const { id, title, price, imgMin } = arrayElem;
        goodsWrapper.appendChild(
          createCardGoods(id, title, price, imgMin)
        );
      });
    } else {
      goodsWrapper.textContent = '🙁 Sorry, nothing has found.';
    };
  }

  // Shopping Cart :

  const createShoppingCart = (id, title, price, img) => {
    const card = document.createElement('div');
    card.className = 'goods';
    card.innerHTML =
      `<div class="goods-img-wrapper">
          <img class="goods-img" src="${img}" alt="">
          </div>
          <div class="goods-description">
            <h2 class="goods-title">${title}</h2>
            <p class="goods-price">${price} ₽</p>
          </div>
          <div class="goods-price-count">
            <div class="goods-trigger">
              <button data-goods-id="${id}"
                class="card-add-wishlist ${wishlist.includes(id) ? 'active' : ''}"> <!-- MARKED AS FAV AFTER REFRESH PAGE! -->
              </button>
              <button class="goods-delete" data-goods-id="${id}"></button>
            </div>
          <div class="goods-count">1</div>
    </div>`;
    return card;
  };

  const renderShoppingCart = cardsArray => {
    // clear before re-render.
    shopCartWrapperElem.textContent = '';
    if (cardsArray.length) {
      cardsArray.forEach((arrayElem) => {
        const { id, title, price, imgMin } = arrayElem;
        shopCartWrapperElem.appendChild(
          createShoppingCart(id, title, price, imgMin)
        );
      });
    } else {
      shopCartWrapperElem.innerHTML =
        '<div id="cart-empty">🙁 Sorry, your shopping cart is empty.</div>';
    };
  }

  const openCart = event => {
    // Set event.defaultPrevented propperty = true.
    // to force prevent reference click action :
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
      getGoodsAndRender(renderCard,
        goods => goods.filter(item => item.category.includes(selectedCat)));
    }
  };

  const searchGoods = event => {
    event.preventDefault();

    // event.target.elements === HTMLFormControlsCollection
    const searchValue = event.target.elements.searchGoods.value.trim();

    if (searchValue === '') {
      search.classList.add('error');
      setTimeout(() => {
        search.classList.remove('error');
      }, 3000);
    } else {
      const search = new RegExp(searchValue, 'i');
      getGoodsAndRender(renderCard, goods => goods.filter(item => search.test(item.title)));
      // OR (method 2) :
      // getGoodsAndRender(renderCard, goods => goods.filter(item => item.title.toLowerCase().includes(searchValue.toLowerCase())));
    }
  };

  const toggleWishList = (id, element) => {
    if (wishlist.includes(id)) {
      wishlist.splice(wishlist.indexOf(id), 1);
      element.classList.remove('active');  // Unmark goods as fav
    } else {
      wishlist.push(id);
      element.classList.add('active'); // Mark goods as fav
    }
    storageQuery();
  }

  const addShoppingCart = id => {
    if (goodsBasket[id]) {
      goodsBasket[id] += 1; // increment
    } else {
      goodsBasket[id] = 1; // add first
    }
    
    // TEST :
    console.log(goodsBasket);
    
    checkCounter();

  }

  const goodsHandler = event => {
    const target = event.target;
    if (target.classList.contains('card-add-wishlist')) {
      // !!!!!!!!!!!! <button data-goods-id="xxx"
      toggleWishList(target.dataset.goodsId, target);
    }
    if (target.classList.contains('card-add-cart')) {
      addShoppingCart(target.dataset.goodsId);
    }
  }

  const showWishlist = () => {
    getGoodsAndRender(renderCard, goods => goods.filter(item => wishlist.includes(item.id)));
  }

  cardBtn.addEventListener('click', openCart);
  cart.addEventListener('click', closeCart);
  category.addEventListener('click', chooseCategory);
  search.addEventListener('submit', searchGoods);
  goodsWrapper.addEventListener('click', goodsHandler);
  wishlistBtn.addEventListener('click', showWishlist);

  //... getGoodsAndRender = (handler, filter = undefined by default and will be skipped if PROMISES (.then(undefined))
  const getGoodsAndRender = (handler, filter) => {
    showLoadingSpinner();
    fetch('db/db.json')
      .then((rez) => { return rez.json(); })
      .then(filter)
      .then(handler);
  }

  const randomSort = (array) => array.sort(() => Math.random() - 0.5);

  getGoodsAndRender(renderCard, randomSort);








  //
  // END of
  // document.addEventListener('DOMContentLoaded', function() {
});