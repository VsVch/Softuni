import { html } from "../node_modules/lit-html/lit-html.js"

import * as authSerice from './../sevices/authService.js'

const loginTemplate = (onSubmit) => html`

</form>
<div class="login-container">
    <h3>Login Page</h3>
    <form action="" @submit=${onSubmit}>
        <div class="mb-3 row">
            <label for="email" class="col-sm-2 col-form-label">Email</label>
            <div class="col-sm-10">
                <input type="text" class="form-control" id="staticEmail" name="email">
            </div>
        </div>
        <div class="mb-3 row">
            <label for="password" class="col-sm-2 col-form-label">Password</label>
            <div class="col-sm-10">
                <input type="password" class="form-control" id="inputPassword" name="password">
            </div>
        </div>
        <div class="mb-3 row">            
            <div style="width: 200px">
                <input type="submit" class="form-control"> 
            </div>
        </div>        
    </form>
</div>`

export function loginPage(ctx) {

    const onLoginSubmit = (e) => {
        e.preventDefault();
        let formDate = new FormData(e.currentTarget);

        let email = formDate.get('email');
        let password = formDate.get('password').trim();
       
        if (!email || !password) {
            return;
        }

        authSerice.login(email, password)
        .then(() => {
            ctx.page.redirect('/');
        })

    }

    ctx.render(loginTemplate(onLoginSubmit));

}