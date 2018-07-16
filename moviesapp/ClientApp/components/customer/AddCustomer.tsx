import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';
import { CustomerData } from './FetchCustomer';

interface AddCustomerDataState {
    title: string;
    loading: boolean;
    objData: CustomerData;
}

export class AddCustomer extends React.Component<RouteComponentProps<{}>, AddCustomerDataState> {
    constructor(props) {
        super(props);

        this.state = { title: "", loading: true, objData: new CustomerData };

        var customerid = this.props.match.params["customerid"];

        // This will set state for Edit customer
        if (customerid > 0) {          

            fetch('api/Customers/Details/' + customerid)
                .then(response => response.json() as Promise<CustomerData>)
                .then(data => {
                    this.setState({ title: "Edit", loading: false, objData: data });
                });
        }

        // This will set state for Add customer
        else {
            this.state = { title: "Create", loading: false, objData: new CustomerData };
        }

        // This binding is necessary to make "this" work in the callback
        this.handleSave = this.handleSave.bind(this);
        this.handleCancel = this.handleCancel.bind(this);
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderCreateForm();

        return <div>
            <h1>{this.state.title}</h1>
            <h3>Customer</h3>
            <hr />
            {contents}
        </div>;
    }

    // This will handle the submit form event.
    private handleSave(event) {
        event.preventDefault();
        const data = new FormData(event.target);
        
        // PUT request for Edit customer.
        if (this.state.objData.customerId) {
            fetch('api/Customers/Edit', {
                method: 'PUT',
                body: data,

            }).then((response) => response.json())
                .then((responseJson) => {
                    console.log(responseJson);
                    this.props.history.push("/fetchcustomers");
                })
        }

        // POST request for Add customer.
        else {
            fetch('api/Customers/Create', {
                method: 'POST',
                body: data,

            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/fetchcustomers");
                })
        }
    }

    // This will handle Cancel button click event.
    private handleCancel(e) {
        e.preventDefault();
        this.props.history.push("/fetchcustomers");
    }

    // Returns the HTML Form to the render() method.
    private renderCreateForm() {
        return (
            <form onSubmit={this.handleSave} >
                <div className="form-group row" >
                    <input type="hidden" name="CustomerID" value={this.state.objData.customerId} />
                </div>
                <div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Name">Name</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="Name" defaultValue={this.state.objData.name} required />
                    </div>
                </div> 
                <div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Phone">Phone</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="Phone" defaultValue={this.state.objData.phone} required />
                    </div>
                </div> 
                <div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Email">Email</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="Email" defaultValue={this.state.objData.email} required />
                    </div>
                </div> 
                <div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="homeAddress">Home Address</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="homeAddress" defaultValue={this.state.objData.homeAddress} required />
                    </div>
                </div> 
                <div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Cpf">CPF</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="Cpf" defaultValue={this.state.objData.cpf} required />
                    </div>
                </div>                 
                <div className="form-group">
                    <button type="submit" className="btn btn-default">Save</button>
                    <button className="btn" onClick={this.handleCancel}>Cancel</button>
                </div >
            </form >
        )
    }
}