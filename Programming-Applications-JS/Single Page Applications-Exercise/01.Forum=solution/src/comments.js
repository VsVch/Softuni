
import { e } from './dom.js'

let divCintener = document.querySelector('.container');
let body = document.querySelector('body');

export function showComents(e) {
    
    let title = e.target;    
   
    divCintener.style.display = 'none'  
   
    let compount = createCommentSection(title);

    body.appendChild(compount);
}

function createCommentSection(articleName) {

    let mainDiv = e('div', { className: 'coment-container' });

    mainDiv.innerHTML = `
    <div class="theme-content">       
        <div class="theme-title">
            <div class="theme-name-wrapper">
                <div class="theme-name">
                  <h2> ${articleName.textContent} </h2>
                </div>
            </div>
        </div>       

        <div class="put-comment">

        </div>

        <div class="answer-comment">
            <p><span>currentUser</span> comment:</p>
            <div class="answer">
                <form>
                    <textarea name="postText" id="comment" cols="30" rows="10"></textarea>
                    <div>
                        <label for="username">Username <span class="red">*</span></label>
                        <input type="text" name="username" id="username">
                    </div>
                    <button>Post</button>
                    
                </form>
            </div>
        </div>
    </div>`;   

    return mainDiv;
}

