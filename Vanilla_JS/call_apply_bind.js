import '../styles/index.scss';

console.log(' = = =  CALL (OVERRIDE THIS.) : = = =  ');

let objA = {
    id: 123,
    getId: function() {
        return this.id;
    }
};

let objB = { id: 456 };

// call function of object-A with THIS-pointed to object-B
console.log(objA.getId.call(objB)); // 456

console.log(' = = =  APPLY (LIKE A CALL WITH PARAMS) : = = =  ');

let objC = {
    id: 123,
    getId: function(prefix, suffix) {
        return prefix + this.id + suffix;
    }
};

let objD = { id: 456 };

// like a CALL with Params - ...SomeFunc.apply(objFor.This, [SomeFunc-parameters])
console.log(objC.getId.apply(objD, ['New ID: ', ' !!!'])); // New ID : 456

console.log(' = = =  BIND : = = =  ');

let objE = {
    id: 123,
    eee: 666,
    getId: function() {
        return this.id; // + this.eee; - with it result = NaN (objF has no 'eee')
    }
};

let objF = { id: 456 };

// BIND function of object-E to the object-F 
let getIdNew = objE.getId.bind(objF);

console.log(getIdNew()); // 456