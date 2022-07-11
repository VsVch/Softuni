import { useState, useEffect } from "react";

import * as UserService from "../../services/UserService.js";
import { UserConstants } from "../user-section/UserConstants.js";

import { UserDetails } from "./user-section-components/UserDetails.js";
import { UserTableBody } from "./user-section-components/UserTableBody.js";
import { UserTableHead } from "./user-section-components/UserTableHead.js";
import { UserEdit } from "./user-edit/UserEdit.js";
import { UserDelete } from "./user-delete/UserDelete.js";
import { UserAdd } from "./user-add/UserAdd.js";

export const UserSection = () => {
  const [userAction, setUserAction] = useState({ user: null, action: null });
  const [users, setUsers] = useState([]);  

  useEffect(() => {
    UserService.getAll().then((result) => setUsers(result));
  }, []);

  const userActionClickHandler = (userId, actionType) => {    
      UserService.getOne(userId).then((user) => {
        setUserAction({
          user,
          action: actionType,
        });
      });
  };  

  const closeHandler = () => {
    setUserAction({ user: null, actionType: null });
  };

  const userCreateClickHandler = (e) => {
    e.preventDefault();

    const formData = new FormData(e.target);
    const {
      firstName,
      lastName,
      email,
      imageUrl,
      phoneNumber,
      ...address
    } = Object.fromEntries(formData);

    const userData = {
      firstName,
      lastName,
      email,
      imageUrl,
      phoneNumber,
      address,
    };

    UserService.create(userData)
    .then((user) => {
      const newUser = UserService.getAll().then((result) => setUsers(result));
      setUsers(newUser => [...newUser])
      closeHandler();
    });
  };

  const userEditClickHandler =(e)=> {
    e.preventDefault();

  console.log(e.target); 

    const formData = new FormData(e.target);
    const {
      firstName,
      lastName,
      email,
      imageUrl,
      phoneNumber,
      ...address
    } = Object.fromEntries(formData);

    const userData = {
      firstName,
      lastName,
      email,
      imageUrl,
      phoneNumber,
      address,
    };

    const userId = 1;
    
    UserService.editOne(userId, userData)
      .then((user) => {
        UserService.getAll().then((result) => setUsers(result));
        closeHandler();      
    }); 
  }

  const userDeleteClickHandler = (userId) => {
    UserService.deleteOne(userId)      
    .then((userId) => {
      UserService.getAll().then((result) => setUsers(result));
      closeHandler();      
    });
  }

  return (
    <>
      <div className="table-wrapper">
        {userAction.action == UserConstants.Details && (
          <UserDetails
            {...userAction.user}
            onCloseHandler={closeHandler}
            onActionClick={userActionClickHandler}
          />
        )}
        {userAction.action == UserConstants.Edit && (
          <UserEdit
            {...userAction.user}
            onCloseHandler={closeHandler}
            onActionClick={userActionClickHandler}
            onEditHendler={userEditClickHandler}
          />
        )}
        {userAction.action == UserConstants.Delete && (
          <UserDelete
            {...userAction.user}
            onCloseHandler={closeHandler}
            onActionClick={userActionClickHandler}
            onDeleteHendler={userDeleteClickHandler}
          />
        )}
        {userAction.action == UserConstants.Add && (
          <UserAdd
            onCloseHandler={closeHandler}
            onUserCreate={userCreateClickHandler}
          />
        )}

        <table className="table">
          <thead>
            <UserTableHead />
          </thead>
          <tbody>
            {users.map((user) => (
              <UserTableBody
                key={user._id}
                {...user}
                onActionClick={userActionClickHandler}
              />
            ))}
          </tbody>
        </table>
      </div>
      <button
        className="btn-add btn"
        onClick={() => userActionClickHandler(null, UserConstants.Add)}
      >
        Add new user
      </button>
    </>
  );
};
