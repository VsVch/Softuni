const { assert } = require('chai');
const ChristmasMovies = require('../02. Christmas Movies');

describe("Tests ChristmasMovies", function () {
    describe("buyMovie", () => {

        it('Should return correct messege when movie is undefined', () => {

            let christmas = new ChristmasMovies();

            let actors = ['Misho', 'Lubi', 'Mariq'];
            let expect = `You just got sasho to your collection in which Misho, Lubi, Mariq are taking part!`

            assert.strictEqual(christmas.buyMovie('sasho', actors), expect)
        });

        it('Should throw error when movie exsist in colection', () => {

            let christmas = new ChristmasMovies();
            let actors = ['Misho', 'Lubi', 'Mariq'];
            christmas.movieCollection.push({ name: 'sasho', actors: actors });
            let movieName = 'sasho';


            let expect = `You already own sasho in your collection!`;

            assert.throw(() => christmas.buyMovie(movieName, actors), Error, expect)
        });
    });

    describe("discardMovie", () => {

        it('Should throw error when movie colection length is equal to 0', () => {

            let christmas = new ChristmasMovies();

            let colection = christmas.movieCollection
            let movieName = 'sasho';

            let expect = 'sasho is not at your collection!';

            assert.throw(() => christmas.discardMovie(movieName), Error, expect)
        });

        it('Should throw error when movie dosent exist in object', () => {

            let christmas = new ChristmasMovies();
            let actors = ['Misho', 'Lubi', 'Mariq'];
            christmas.movieCollection = [{ name: 'sasho', actors: actors }];
            let movieName = 'sasho';


            let expect = `sasho is not watched!`;

            assert.throw(() => christmas.discardMovie(movieName), Error, expect)
        });

        it('Should return message when movie exsist in object', () => {

            let christmas = new ChristmasMovies();
            let actors = ['Misho', 'Lubi', 'Mariq'];
            christmas.movieCollection = [{ name: 'sasho', actors: actors }];
            let movieName = 'sasho';
            christmas.watched[movieName] = 'sasho';


            let expect = `You just threw away sasho!`;

            assert.strictEqual(christmas.discardMovie(movieName), expect)
        });
    });

    describe("watchMovie", () => {

        it('Should throw error when movie dosent exist', () => {

            let christmas = new ChristmasMovies();
            let movieName = '';

            let expect = 'No such movie in your collection!';

            assert.throw(() => christmas.watchMovie(movieName), Error, expect)
        });

        it('Should return new property count 1', () => {

            let christmas = new ChristmasMovies();         
           
            christmas.buyMovie('sasho',['Misho', 'Lubi', 'Mariq']);
           
            christmas.watchMovie('sasho'); 
            christmas.watchMovie('sasho'); 
                       

            assert.strictEqual(christmas.watched['sasho'], 2)
        });
       
    });

    describe("favouriteMovie", () => {

        it('Should return favorite movie', () => {

            let christmas = new ChristmasMovies();
            christmas.watched =
            {
                'a': 2,
            },
            {
                'b': 1
            },

                assert.strictEqual(christmas.favouriteMovie(), `Your favourite movie is a and you have watched it 2 times!`)
        });

        it('Should throw exeption when object is empty', () => {

            let christmas = new ChristmasMovies();          

            let expect = 'You have not watched a movie yet this year!';

            assert.throw(() => christmas.favouriteMovie(), Error, expect)
        });
    });

    describe("mostStarredActor", () => {

        it('Should trow error', () => {

            let christmas = new ChristmasMovies();
            christmas.movieCollection = [];

            let expect = 'You have not watched a movie yet this year!';

            assert.throw(() => christmas.mostStarredActor(), Error, expect)
        });        
    });

    describe("mostStarredActor", () => {

        it('Should trow error', () => {

            let christmas = new ChristmasMovies();
            christmas.buyMovie('sasho',['Misho', 'Lubi', 'Mariq,']);
            christmas.buyMovie('rasho',['Sasho', 'Teme', 'Mariq,']);

            let expect = `The most starred actor is Mariq, and starred in 2 movies!`;;

            assert.strictEqual(christmas.mostStarredActor(),expect)
        });        
    });
});
