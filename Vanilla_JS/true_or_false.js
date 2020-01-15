function fn(value) {
    return true - value;
}

console.log(fn('4'));   // -3
console.log(fn('-4'));  // 5
console.log(fn(-'4'));  // 5
console.log(fn(4));     // -3

// ==================================

function isTruthVal(value) {
    if (value)
        console.log("is Truth.");
    else console.log("is Not Truth.");
}
// is FALSE :
isTruthVal(NaN == NaN);       // is Not Truth.
isTruthVal(undefined);// is Not Truth.
isTruthVal(NaN);     // is Not Truth.
isTruthVal(null);    // is Not Truth.
isTruthVal(0);       // is Not Truth.
isTruthVal("");      // is Not Truth.
isTruthVal(false);   // is Not Truth.
// is TRUE :
isTruthVal("false"); // is Truth.
isTruthVal(1);       // is Truth.
isTruthVal(-1);      // is Truth.
isTruthVal([]);      // is Truth.
isTruthVal({});      // is Truth.
isTruthVal(null == undefined);// is Truth.
isTruthVal(typeof (null) == "object"); // is Truth.

