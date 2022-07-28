import { useEffect, useContext } from "react";
import { useNavigate } from "react-router-dom";

import { AuthContext } from "../../contexts/AuthContext.js";
import * as authService from '../../services/authService.js';

const Logout = () => {
    const navigate = useNavigate();
    const {user, userlogout} = useContext(AuthContext);

    useEffect(() => {
        authService.logout(user.accessToken)
            .then(()=> {
                userlogout();
                navigate('/');
            })
            .catch(() => {
                navigate('/'); 
            });
    });

    return null;
};

export default Logout;
