const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

let browser, page;
let clientUrl = 'http://127.0.0.1:5500/index.html'

function fakeResponse(date) {
    return {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(date),
    }
}

let testMesseges = {
    1: {
        author: 'Pesho',
        content: 'My message'
    },
    2: {
        author: 'George',
        content: 'My George message'
    },
}

let testCreateMessage = {
    3: {
        author: 'Ivan',
        content: 'Ivans message',
        _id: 3
    },
}

describe('E2E tests', function () {
    before(async () => { browser = await chromium.launch(); });
    after(async () => { await browser.close(); });
    beforeEach(async () => { page = await browser.newPage(); })
    this.afterEach(async () => { await page.close(); });

    describe('load messages', () => {
        it('should call server', async () => {

            await page.route('**/jsonstore/messenger', route => {

                route.fulfill(fakeResponse(testMesseges))
            });

            await page.goto(clientUrl);


            const [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/messenger'),
                page.click('#refresh'),
            ]);
            let result = await response.json();
            expect(result).to.eql(testMesseges);
        });

        it('should show date in text area', async () => {

            await page.route('**/jsonstore/messenger', route => {

                route.fulfill(fakeResponse(testMesseges))
            });

            await page.goto(clientUrl);


            const [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/messenger'),
                page.click('#refresh'),
            ]);

            let textAreaText = await page.$eval('#messages', (textArea) => textArea.value);
            let text = Object.values(testMesseges)
                .map(x => `${x.author}: ${x.content}`)
                .join('\n')
            expect(textAreaText).to.eql(text);
        });
    })

    describe('create messages', () => {
        it ('should call server whit correct date', async () => {
            let requestDate = undefined;

            let expected = {
                author: 'Ivan',
                content: 'Ivans message'
            }

            await page.route('**/jsonstore/messenger', (route, request) => {
                if (request.method().toLowerCase() === 'post') {
                    requestDate = request.postData();
                    route.fulfill(fakeResponse(testCreateMessage))
                }

            });

            await page.goto(clientUrl);

            await page.fill('#author', expected.author);
            await page.fill('#content', expected.content);


            const [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/messenger'),
                page.click('#submit'),
            ]);          

            let result = JSON.parse(requestDate);
            expect(result).to.eql(expected);
        });

        it ('should clear input', async () => {
            let requestDate = undefined;

            let expected = {
                author: 'Ivan',
                content: 'Ivans message'
            }

            await page.route('**/jsonstore/messenger', (route, request) => {
                if (request.method().toLowerCase() === 'post') {
                    requestDate = request.postData();
                    route.fulfill(fakeResponse(testCreateMessage))
                }

            });

            await page.goto(clientUrl);

            await page.fill('#author', expected.author);
            await page.fill('#content', expected.content);


            const [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/messenger'),
                page.click('#submit'),
            ]); 
            
            let authorValue = await page.$eval('#author', a=> a.value);
            let contentInput = await page.$eval('#content', c=> c.value);

           
            expect(authorValue).to.equal('');
            expect(contentInput).to.equal('');
        });
    })



});