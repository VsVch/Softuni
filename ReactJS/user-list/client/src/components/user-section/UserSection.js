import { UserDetailsInfo } from "./user-section-components/UserDetailsInfo.js";
import { UserTableBody } from "./user-section-components/UserTableBody.js";
import { UserTableHead } from "./user-section-components/UserTableHead.js"

export const UserSection = (props) => {
  
    const detailsClickHandler = (userId) => {
        console.log(userId);
    };

  return (
    <div className="table-wrapper">
      <table className="table">
        {/* <UserDetailsInfo /> */}
		<thead>
			<UserTableHead/>
		</thead>        
        <tbody>
			{props.users.map(user => <UserTableBody key={user._id} {...user} onDetailsClick={detailsClickHandler}/>)}
		</tbody>        
      </table>
    </div>
  );
};
