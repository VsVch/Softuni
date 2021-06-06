function solve() {
   let addProductButtons = document.querySelectorAll('.add-product');
   let textAreaElementr = document.querySelector('textarea');
   let checkoutButton = document.querySelector('.checkout');

   let totalPrice = 0;

   let products = [];

   for (const addProductButton of addProductButtons) {

      addProductButton.addEventListener('click', (e) => {
         let currentProductElement = e.currentTarget.parentElement.parentElement;
         let productName = currentProductElement.querySelector('.product-title').textContent;
         let procuctPrice = Number(currentProductElement.querySelector('.product-line-price').textContent);

         totalPrice += procuctPrice;
         products.push(productName);

         textAreaElementr.textContent += `Added ${productName} for ${procuctPrice.toFixed(2)} to the cart.\n`
      });
   }
   checkoutButton.addEventListener('click', (e)=>{
      let uniqeElements = products.reduce((a, x) => {
         if(!a.includes(x)){
            a.push(x);
         }
         return a;
      },[]);
      textAreaElementr.textContent += `You bought ${uniqeElements.join(', ')} for ${totalPrice.toFixed(2)}.`
   })
}