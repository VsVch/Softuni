let guestCount = 99;

let weddingPromise = new Promise(function (resolve, reject) {

    if (guestCount > 100) {
        setTimeout(function () {
            reject('Wedding is to big!');
        }, 1000);
    } else {
        setTimeout(function () {
            resolve('Let\'s get merry!');
        }, 4000);
    }
});
weddingPromise
    .then(function (messege) {
        console.log('Promise fufilled!');
        console.log(messege);
    })
    .catch(function (reason) {
        console.log('Promis rejected!')
        console.log(reason);
    })

//easy way to do promises

let alwaysReject = Promise.reject('Reject');
let alwaysResolve = Promise.resolve('Agree');

// alwaysReject.catch();
// alwaysResolve.then()

// array from promises

let allPromises = Promise.all([
    weddingPromise,
    alwaysReject,
    alwaysResolve
])

allPromises
    .then(function (messege) {
        console.log('All resolve');
    })
    .catch(function (err) {
        console.log('at least one failed')
    })
    .finally(function () {
        console.log('At the end');
    });