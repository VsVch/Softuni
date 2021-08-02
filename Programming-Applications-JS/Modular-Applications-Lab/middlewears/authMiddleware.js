import * as authService from '../sevices/authService.js';

export function authMiddleware(ctx, next){

   console.log(ctx)

    let userData = authService.getData();

    if (userData.accessToken) {
        ctx.isAuthenticated = true;
        ctx.email = userData.email;
        ctx.token = userData.token;
    }    
    next();
}