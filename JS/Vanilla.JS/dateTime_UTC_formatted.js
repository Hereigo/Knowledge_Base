
let now = new Date('1.1.20 3:1:1');

let formatted_date = 'Formatted UTC time : ' + 
    ('0' + now.getUTCDate()).slice(-2) + "." + 
    ('0' + (now.getUTCMonth() + 1)).slice(-2) + "." +
    now.getUTCFullYear() + " " + 
    ('0' + now.getUTCHours()).slice(-2) + ":" + ('0' + now.getUTCMinutes()).slice(-2) + ":" + ('0' + now.getUTCSeconds()).slice(-2) + ' GMT';

console.log(formatted_date);

console.log('Formatted UTC time : 01.01.2020 13:52:36 GMT (expected)');