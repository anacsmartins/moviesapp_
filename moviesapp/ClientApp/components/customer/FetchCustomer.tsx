import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';

interface FetchCustomersDataState {
    customerList: CustomerData[];
    loading: boolean;
}

export class FetchCustomers extends React.Component<RouteComponentProps<{}>, FetchCustomersDataState> {
    constructor() {
        super();
        this.state = { customerList: [], loading: true };

        fetch('api/Customers/Index')
            .then(response => response.json() as Promise<CustomerData[]>)
            .then(data => {
                this.setState({ customerList: data, loading: false });
            });

       // This binding is necessary to make "this" work in the callback
        this.handleDelete = this.handleDelete.bind(this);
        this.handleEdit = this.handleEdit.bind(this);

    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderCustomersTable(this.state.customerList);

        return <div>
            <h1>Customers Data</h1>
            <p>
                <Link to="/addcustomer">Create New</Link>
            </p>
            {contents}
        </div>;
    }

    // Handle Delete request for an customer
    private handleDelete(id: number) {
        if (!confirm("Do you want to delete customer with Id: " + id))
            return;
        else {
            fetch('api/Customers/Delete/' + id, {
                method: 'delete'
            }).then(data => {
                this.setState(
                    {
                        customerList: this.state.customerList.filter((rec) => {
                            return (rec.customerId != id);
                        })
                    });
            });
        }
    }

    private handleEdit(id: number) {
        this.props.history.push("/customer/edit/" + id);
    }

    // Returns the HTML table to the render() method.
    private renderCustomersTable(customerList: CustomerData[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th></th>
                    <th>CustomersId</th>
                    <th>Name</th>
                    <th>Phone</th>
                    <th>Cpf</th>
                    <th>Email</th>
                    <th>Home Address</th>
                </tr>
            </thead>
            <tbody>
                {customerList.map(customer =>
                    <tr key={customer.customerId}>
                        <td></td>
                        <td>{customer.customerId}</td>
                        <td>{customer.name}</td>
                        <td>{customer.phone}</td>
                        <td>{customer.cpf}</td>
                        <td>{customer.email}</td>
                        <td>{customer.homeAddress}</td>
                        <td>
                            <a className="action" onClick={(id) => this.handleEdit(customer.customerId)}>Edit</a>  |
                            <a className="action" onClick={(id) => this.handleDelete(customer.customerId)}>Delete</a>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}

export class CustomerData {
    customerId: number = 0;
    name: string = "";
    email: string = "";
    phone: string = "";
    homeAddress: string = "";
    cpf: string = "";
} 