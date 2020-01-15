// SUBSRINGS OF BIG TEXT CAN HAVE MANY REFERENCES TO PREVENT GC WORK !

// SOMETIMES STRINGS SHOULD BE CLEANED FROM REFERENCES :

function clearStringFast(str) {

    return str.length < 12 ? str : (' ' + str).slice(1);
}