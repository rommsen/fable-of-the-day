# fable-of-the-day

This is a F#/Fable port of the Catch of the day application used in @wesbos' [awesome course to learn React](https://reactforbeginners.com/).

Here you can find a video of the application: https://reactforbeginners.com/images/using.mp4

The running application itself can be found here: https://fable-of-the-day.firebaseapp.com

It showcases how to do different things in Fable/Fable-React:

* Building React Components with Fable: https://github.com/rommsen/fable-of-the-day/blob/c7b701a91dc7133090ade924b467788d6879bb67/src/fable/App.fs#L53
* Including external JS: https://github.com/rommsen/fable-of-the-day/blob/c7b701a91dc7133090ade924b467788d6879bb67/src/fable/Helpers.fs#L7
* Including React-Components written in JS: https://github.com/rommsen/fable-of-the-day/blob/c7b701a91dc7133090ade924b467788d6879bb67/src/fable/App.fs#L29
* Using LocalStorage with Fable.PowerPack: https://github.com/rommsen/fable-of-the-day/blob/c7b701a91dc7133090ade924b467788d6879bb67/src/fable/App.fs#L118
* Working with promises: https://github.com/rommsen/fable-of-the-day/blob/c7b701a91dc7133090ade924b467788d6879bb67/src/fable/App.fs#L126
* Using Firebase (created with ts2fable): https://github.com/rommsen/fable-of-the-day/blob/master/src/fable/import/Firebase.fs
* Using Re-Base: https://github.com/rommsen/fable-of-the-day/blob/c7b701a91dc7133090ade924b467788d6879bb67/src/fable/Base.fs#L21


Use it locally:
* git clone
* dotnet restore
* yarn install
* npm start
* go to localhost:3000
* you might want to create your own Firebase App and put the credentials here: https://github.com/rommsen/fable-of-the-day/blob/c7b701a91dc7133090ade924b467788d6879bb67/src/fable/Base.fs#L12
