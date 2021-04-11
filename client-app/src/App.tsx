import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

function App() {
  const [activities, setActivities] = useState([]); //name of var to store state, function to set the state, then react hook useState

  useEffect(() => {
    axios.get('http://localhost:5000/api/activities').then(response => { //set activities to the response that we get back from axios 
      console.log(response);
      setActivities(response.data);
    })
  }, []) //add array of dependencies, to ensure this only runs once instead of as a loop

  return (
    <div>
      <Header as='h2' icon='users' content='Reactivities' />

        <List>
        {activities.map((activity: any) => (
            <List.Item key={activity.id}>
              {activity.title}
            </List.Item>
          ))}
        </List>

    </div>
  );
}

export default App;
