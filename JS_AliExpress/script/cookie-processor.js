// copied from learn.javascript.ru.

// returned cookie by it's name or return undefined :
const getCookie = (name) => {
    let matches = document.cookie.match(new RegExp(
        "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    // matches[0] - cookie name, matches[1] - cookie value
    return matches ? decodeURIComponent(matches[1]) : undefined;
}

// set Cookies :
const setCookie = (name, value, options = {}) => {

    options = {
        path: '/',
        // ...options
    };

    if (options.expires instanceof Date) {
        options.expires = options.expires.toUTCString();
    }

    let updatedCookie = encodeURIComponent(name) + "=" + encodeURIComponent(value);

    for (let optionKey in options) {
        updatedCookie += "; " + optionKey;
        let optionValue = options[optionKey];
        if (optionValue !== true) {
            updatedCookie += "=" + optionValue;
        }
    }

    document.cookie = updatedCookie;
}
// HowTo use :
// setCookie('user', 'John', {secure: true, 'max-age': 3600});

// delete Cookie by its name :
function deleteCookie(name) {
    setCookie(name, "", {
        'max-age': -1
    })
}