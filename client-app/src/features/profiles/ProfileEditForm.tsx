import { observer } from 'mobx-react-lite';
import React from 'react';
import { useStore } from '../../app/stores/store';
import * as Yup from 'yup';
import { Form, Formik } from 'formik';
import MyTextInput from '../../app/common/form/MyTextInput';
import MyTextArea from '../../app/common/form/MyTextArea';
import { Button } from 'semantic-ui-react';
import { Link } from 'react-router-dom';

interface Props {
    setEditMode: (editMode: boolean) => void; 
}

export default observer(function ProfileEditForm({setEditMode}: Props) {
const {profileStore: {profile, updateProfile}} = useStore();


const validationSchema = Yup.object({
    displayName: Yup.string().required('A username is required')  //validating each field
    
    })

    return (
        <Formik
            validationSchema={validationSchema}
            enableReinitialize
            initialValues={{displayName: profile?.displayName, bio: profile?.bio}}
            onSubmit={values => {
                updateProfile(values).then(() => {
                    setEditMode(false);
            }) 
        }}
            >
            {({ handleSubmit, isValid, isSubmitting, dirty }) => (
                <Form className='ui form' onSubmit={handleSubmit} autoComplete='off'>
                    <MyTextInput name='displayName' placeholder='Display Name' />
                    <MyTextArea rows={3} placeholder='Add a Bio' name='bio' />
                    <Button
                        disable={isSubmitting || dirty || isValid}
                        loading={isSubmitting} floated='right' positive type='submit' content='Update Profile' />
                    <Button as={Link} to='/activities' floated='right' type='button' content='Cancel' />
                </Form>
            )}
        </Formik>
    )
})