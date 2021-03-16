function get(url) {

  return new Promise(function (succeed, fail) {

    var request = new XMLHttpRequest();
    request.open('GET', url, true);

    request.addEventListener('load', function () {
      if (request.status < 400)
        succeed(request.response);
      else
        fail(new Error('Request failed: ' + request.statusText));
    });

    request.addEventListener('error', function () {
      fail(new Error('Network error'));
    });

    request.send();
  });
}

get('https://jsonplaceholder.typicode.com/users/1')
  .then(
    function (succeededResult) {
      console.log(succeededResult);
      return JSON.parse(succeededResult);
    }
    // , function (failedResult) {
    //   console.log('Error !!! (in then 2nd)');
    //   console.log(failedResult);
    // }
  ).then(
    function (returnOfPreviousTHEN) {
      console.log('EMAIL : ', returnOfPreviousTHEN.email);
    }
  )
  .catch(
    function (catchResultAsUnsuccessful) {
      console.log('Error!!! (in catch)');
      console.log(catchResultAsUnsuccessful);
    }
  )
  .then(
    function () {
      console.log('\r\n === SENDING POST ===  ...');
    }
  );

// === SENDING POST === :

function post(url, requestuestBody) {

  return new Promise(function (succeed, fail) {

    var request = new XMLHttpRequest();
    request.open('POST', url, true);
    request.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');

    request.addEventListener('load', function () {
      if (request.status < 400)
        succeed(request.responseText);
      else
        fail(new Error('Request failed: ' + request.statusText));
    });

    request.addEventListener('error', function () {
      fail(new Error('Network error'));
    });

    request.send(requestuestBody);
  });
}

var user = {
  name: 'Tom&Tim',
  age: 23
};

var params = 'name=' + user.name + '&age=' + user.age;

post('http://localhost:8080/postdata.php', params).then(function (text) {
  console.log(text);
}, function (error) {
  console.log(error);
});