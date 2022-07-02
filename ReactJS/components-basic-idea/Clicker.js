import { useState } from "react";

export const Clicker = (props) => {
  const [clicks, setClicks] = useState(0);

  const clickHandelr = (event) => {
    setClicks((clicks) => clicks + 1);
  };

  const dangerClicks = clicks > 20;

  if(clicks > 30){
    return <h1>Finished Clicks</h1>
  }
  
  return (
    <div>
      <div>
        {dangerClicks && <h1>Danger Clicks</h1>}
        {clicks > 10 ? <h3>Medium Clicks</h3> : <h4>Normal Clicks</h4>}
        </div>
      <button onClick={clickHandelr}>{clicks}</button>
    </div>
  );
};
