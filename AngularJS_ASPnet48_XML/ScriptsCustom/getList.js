
app.factory('getList', ['$http', function ($http) {

    return $http.post('/Home/GetList/')
        .success(function (data) {
            return data;
        })
        .error(function (err) {
            return err;
        });
}]); 
