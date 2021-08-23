import authServece from '../../services/authServece.js';
import memeService from '../../services/memeService.js';
import { profilTemplate } from './profilTemplate.js';

async function currentView(context) {

    let userId = authServece.getUserId();

    if (userId === undefined) {
        window.alert('Login required');
        return;
    }  
        
    let memes = await memeService.getMy(userId);

    let person = {
        email: authServece.getEmail(),
        username: authServece.getUserName(),
        gender: authServece.getGender(),
        memes
    }
    
    let templateResult = profilTemplate(person);
    context.getCurrentView(templateResult)
}

export default {
    currentView,
}