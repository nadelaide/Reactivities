import { useField } from 'formik';
import React from 'react';
import { Form, Label, Select } from 'semantic-ui-react';
import { isPropertySignature } from 'typescript';

interface Props { 
    placeholder: string;
    name: string;
    options: any;
    label?: string;
}

export default function MySelectInput(props: Props) {
    const [field, meta, helpers] = useField(props.name);
    return (
        <Form.Field error={meta.touched && !!meta.error}>
            <label>{props.label}</label>
            <Select 
                clearable
                options={props.options}
                value={field.value || null}
                onChange={(e, d) => helpers.setValue(d.value)} // e is event, d is data
                onBlur={() => helpers.setTouched(true)}
                placeholder={props.placeholder}
                />
            {meta.touched && meta.error ? (
                <Label basic color='red'>{meta.error}</Label>
            ) : null}
        </Form.Field>
    )
}