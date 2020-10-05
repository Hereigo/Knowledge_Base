
app.factory('getList', ['$http', function ($http) {

    return $http.post('/Home/GetList/')
        .then(function (data) {
            return data;
        })
        .then(function (err) {
            return err;
        });
}]); 
