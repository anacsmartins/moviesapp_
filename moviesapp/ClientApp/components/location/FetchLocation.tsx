import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';

interface FetchLocationsDataState {
    locationList: LocationData[];
    loading: boolean;
}

export class FetchLocations extends React.Component<RouteComponentProps<{}>, FetchLocationsDataState> {
    constructor() {
        super();
        this.state = { locationList: [], loading: true };

        fetch('api/Locations/Index')
            .then(response => response.json() as Promise<LocationData[]>)
            .then(data => {
                this.setState({ locationList: data, loading: false });
            });

       // This binding is necessary to make "this" work in the callback
        this.handleDelete = this.handleDelete.bind(this);
        this.handleEdit = this.handleEdit.bind(this);

    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderLocationsTable(this.state.locationList);

        return <div>
            <h1>Locations Data</h1>
            <p>
                <Link to="/addlocation">Create New</Link>
            </p>
            {contents}
        </div>;
    }

    // Handle Delete request for an location
    private handleDelete(id: number) {
        if (!confirm("Do you want to delete location with Id: " + id))
            return;
        else {
            fetch('api/Locations/Delete/' + id, {
                method: 'delete'
            }).then(data => {
                this.setState(
                    {
                        locationList: this.state.locationList.filter((rec) => {
                            return (rec.locationId != id);
                        })
                    });
            });
        }
    }

    private handleEdit(id: number) {
        this.props.history.push("/location/edit/" + id);
    }

    // Returns the HTML table to the render() method.
    private renderLocationsTable(locationList: LocationData[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th></th>
                    <th>LocationsId</th>
                    <th>Name</th>
                    <th>MovieId</th>
                    <th>CustomerId</th>
                </tr>
            </thead>
            <tbody>
                {locationList.map(obj =>
                    <tr key={obj.locationId}>
                        <td></td>
                        <td>{obj.locationId}</td>
                        <td>{obj.customerId}</td>
                        <td>{obj.movieId}</td>
                        <td>
                            <a className="action" onClick={(id) => this.handleEdit(obj.locationId)}>Edit</a>  |
                            <a className="action" onClick={(id) => this.handleDelete(obj.locationId)}>Delete</a>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}

export class LocationData {
    locationId: number = 0;
    movieId: number = 0;
    customerId: number = 0;
} 