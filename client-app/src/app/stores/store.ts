import { createContext, useContext } from "react";
import ActivityStore from "./activityStore";
import CommonStore from "./commonStore";
import ModalStore from "./modalStore";
import ProfileStore from "./profileStore";
import UserStore from "./userStore";

interface Store {
    activityStore: ActivityStore
    commonStore: CommonStore;
    userStore: UserStore;
    modalStore: ModalStore;
    profileStore: ProfileStore;
}

export const store: Store = {
    activityStore: new ActivityStore(),
    commonStore : new CommonStore(),
    userStore: new UserStore(),
    modalStore: new ModalStore(),
    profileStore: new ProfileStore()
}

export const StoreContext = createContext(store); //as we create new stores, add new instances above to then make them available in the react context

export function useStore() { //hook used in App.tsx
    return useContext(StoreContext);
}