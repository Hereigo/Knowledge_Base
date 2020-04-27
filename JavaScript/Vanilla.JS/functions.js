import '../styles/index.scss';

console.log(' = = =  CONSTRUCTOR: FUNCTIONS : = = =  ');

function SimpleFunction() {
    console.log(this);
};

SimpleFunction(); // undefined (means - Window ???)

let varStoredFunc = new SimpleFunction(); // Object { proto > constructor: function SimpleFunction() ... }

SimpleFunction(); // undefined 

// varStoredFunc(); - 'varStoredFunc' is not a function

console.log(' = = =  CONSTRUCTOR: FUNCTIONS (2) : = = =  ');

function Function2(id) {

    console.log(this); // Object { funcInside: function funcInside(), idInside: 1212, ... } 

    this.idInside = id;
    this.funcInside = function() {
        console.log('idInside = ' + this.idInside);
    };
}

let Func2storage = new Function2(1212);

// Function2(); - 'id' is undefined
// Function2(111); - 'this' is undefined

Func2storage.funcInside(); // idInside = 1212

console.log(' = = =  PROTOTYPES : = = =  ');

//