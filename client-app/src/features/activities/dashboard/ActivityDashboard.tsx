
import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import { Grid} from 'semantic-ui-react';
import LoadingComponent from '../../../app/layout/LoadingComponents';
import { useStore } from '../../../app/stores/store';
import ActivityFilters from './ActivityFilters';
import ActivityList from './ActivityList';


export default observer(function ActivityDashboard() { //destructured - passing down properties from a different component
    
        const {activityStore} = useStore();
        const {loadActivities, activityRegistry} = activityStore;

        useEffect(() => {
        if (activityRegistry.size <= 1) loadActivities();
        }, [activityRegistry.size, loadActivities]) //add array of dependencies, to ensure this only runs once instead of as a loop

        if (activityStore.loadingInitial) return <LoadingComponent content='Loading app' /> //getting activities from the store

            
        return(
        <Grid>
            <Grid.Column width='10'>
               <ActivityList />
            </Grid.Column>
            <Grid.Column width='6'>
               <ActivityFilters />
            </Grid.Column>
        </Grid>
    ) // only executed if there's something existing in the array
})