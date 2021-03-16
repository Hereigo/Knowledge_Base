
// return fetch('js/services/forecast.json').then(



// create instance of service that use $http

app.factory('forecastSvc', ['$http', function ($http) {
    return $http.get('https://s3.amazonaws.com/codecademy-content/courses/ltp4/forecast-api/forecast.json')
        .success(function (data) {
            return data;
        })
        .error(function (err) {
            return err;
        });
}]); 


// Generalizations
// 
// Why are services useful? Instead of filling the controller with code to fetch weather data from a server, it’s better to move this independent logic into a service so that it can be reused by other parts of the app.
// 
// What can we generalize so far?
// 
//     Directives are a way to make standalone UI components, like <app-info>
//     Services are a way to make standalone communication logic, like forecast which fetches weather data from a server

