import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';
import { LocationData } from './FetchLocation';

interface AddLocationDataState {
    title: string;
    loading: boolean;
    movieList: Array<any>;
    customerList: Array<any>;
    locationData: LocationData;
}

export class AddLocation extends React.Component<RouteComponentProps<{}>, AddLocationDataState> {
    constructor(props) {
        super(props);

        this.state = { title: "", loading: true, movieList: [], customerList: [], locationData: new LocationData };

        fetch('api/Locations/GetMovieList')
            .then(response => response.json() as Promise<Array<any>>)
            .then(data => {
                this.setState({ movieList: data });
            });

        fetch('api/Locations/GetCustomerList')
            .then(response => response.json() as Promise<Array<any>>)
            .then(data => {
                this.setState({ customerList: data });
            });

        var locationid = this.props.match.params["locationid"];

        // This will set state for Edit location
        if (locationid > 0) {          

            fetch('api/Locations/Details/' + locationid)
                .then(response => response.json() as Promise<LocationData>)
                .then(data => {
                    this.setState({ title: "Edit", loading: false, locationData: data });
                });
        }

        // This will set state for Add location
        else {
            this.state = { title: "Create", loading: false, movieList: [], customerList: [],  locationData: new LocationData };
        }

        // This binding is necessary to make "this" work in the callback
        this.handleSave = this.handleSave.bind(this);
        this.handleCancel = this.handleCancel.bind(this);
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderCreateForm(this.state.movieList, this.state.customerList);

        return <div>
            <h1>{this.state.title}</h1>
            <h3>Location</h3>
            <hr />
            {contents}
        </div>;
    }

    // This will handle the submit form event.
    private handleSave(event) {
        event.preventDefault();
        const data = new FormData(event.target);
        
        // PUT request for Edit location.
        if (this.state.locationData.locationId) {
            fetch('api/Locations/Edit', {
                method: 'PUT',
                body: data,

            }).then((response) => response.json())
                .then((responseJson) => {
                    console.log(responseJson);
                    this.props.history.push("/fetchlocations");
                })
        }

        // POST request for Add location.
        else {
            fetch('api/Locations/Create', {
                method: 'POST',
                body: data,

            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/fetchlocations");
                })
        }
    }

    // This will handle Cancel button click event.
    private handleCancel(e) {
        e.preventDefault();
        this.props.history.push("/fetchlocations");
    }

    // Returns the HTML Form to the render() method.
    private renderCreateForm(movieList: Array<any>, customerList: Array<any>) {
        return (
            <form onSubmit={this.handleSave} >
                <div className="form-group row" >
                    <input type="hidden" name="LocationID" value={this.state.locationData.locationId} />
                </div>                           
                
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="MovieID">Movie</label>
                    <div className="col-md-4">
                        <select className="form-control" data-val="true" name="MovieID" defaultValue={this.state.locationData.movieId.toString()} required>
                            <option value="">-- Select Movie --</option>
                            {movieList.map(movie =>
                                <option key={movie.movieId} value={movie.movieId}>{movie.name}</option>
                            )}
                        </select>
                    </div>
                </div >

                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="MovieID">Customer</label>
                    <div className="col-md-4">
                        <select className="form-control" data-val="true" name="CustomerID" defaultValue={this.state.locationData.customerId.toString()} required>
                            <option value="">-- Select Customer --</option>
                            {customerList.map(customer =>
                                <option key={customer.movieId} value={customer.customerId}>{customer.name}</option>
                            )}
                        </select>
                    </div>
                </div >
                <div className="form-group">
                    <button type="submit" className="btn btn-default">Save</button>
                    <button className="btn" onClick={this.handleCancel}>Cancel</button>
                </div >
            </form >
        )
    }
}