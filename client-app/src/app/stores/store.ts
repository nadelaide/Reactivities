import { createContext, useContext } from "react";
import ActivityStore from "./activityStore";

interface Store {
    activityStore: ActivityStore
}

export const store: Store = {
    activityStore: new ActivityStore()
}

export const StoreContext = createContext(store); //as we create new stores, add new instances above to then make them available in the react context

export function useStore() { //hook used in App.tsx
    return useContext(StoreContext);
}