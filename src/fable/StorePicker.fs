module StorePicker

open Fable.Import
open Fable.Helpers.React


// class StorePicker extends React.Component {
//   myInput = React.createRef();
//   static propTypes = {
//     history: PropTypes.object
//   };

//   goToStore = event => {
//     // 1. Stop the form from submitting
//     event.preventDefault();
//     // 2. get the text from that input
//     const storeName = this.myInput.value.value;
//     // 3. Change the page to /store/whatever-they-entered
//     this.props.history.push(`/store/${storeName}`);
//   };
//   render() {
//     return (
//       <form className="store-selector" onSubmit={this.goToStore}>
//         <h2>Please Enter A Store</h2>
//         <input
//           type="text"
//           ref={this.myInput}
//           required
//           placeholder="Store Name"
//           defaultValue={getFunName()}
//         />
//         <button type="submit">Visit Store →</button>
//       </form>
//     );
//   }
// }

// export default StorePicker;

type StorePicker(props) =
  inherit React.Component<obj, obj> (props)

  override this.render() =
    div []
      [
        str "Hello World"
      ]
