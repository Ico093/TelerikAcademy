// These are Java Script literals

var arrayLiteral = ['Rosi', 'Eve', 'Geri', 'Moni'];
var booleanLiteral = true;
var integerLiteral = 35;
var floatingPointLiteral = 3.11;
var objectLiteral = { myName: 'Rosi', myAge: '20', myTown: 'Stara Zagora' };
var stringLiteral = 'First task is done.';
var div = document.getElementById('printLiterals');

console.log('Task1:');
console.log(arrayLiteral);
console.log(booleanLiteral);
console.log(integerLiteral);
console.log(floatingPointLiteral);
console.log(objectLiteral);
console.log(stringLiteral);

div.innerHTML = 'array: ' + arrayLiteral + '</br> boolean: ' + booleanLiteral + '</br> integer: ' + integerLiteral +
    '</br> floating-point: ' + floatingPointLiteral + '</br> object: ' + objectLiteral.myName + '  ' + objectLiteral.myAge + '  ' +
    objectLiteral.myTown + '</br> string: ' + stringLiteral;