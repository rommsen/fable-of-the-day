// ts2fable 0.5.2
module rec Firebase
open System
open Fable.Core
open Fable.Import.JS

let [<Import("*","firebase")>] firebase: Firebase.IExports = jsNative

module Firebase =
    let [<Import("auth","firebase")>] auth: Auth.IExports = jsNative
    let [<Import("database","firebase/firebase")>] database: Database.IExports = jsNative
    let [<Import("storage","firebase/firebase")>] storage: Storage.IExports = jsNative
    let [<Import("firestore","firebase/firebase")>] firestore: Firestore.IExports = jsNative

    type [<AllowNullLiteral>] IExports =
        abstract SDK_VERSION: string
        abstract app: ?name: string -> Firebase.App.App
        abstract apps: ResizeArray<Firebase.App.App option>
        abstract auth: ?app: Firebase.App.App -> Firebase.Auth.Auth
        abstract database: ?app: Firebase.App.App -> Firebase.Database.Database
        abstract initializeApp: options: Object * ?name: string -> Firebase.App.App
        abstract messaging: ?app: Firebase.App.App -> Firebase.Messaging.Messaging
        abstract storage: ?app: Firebase.App.App -> Firebase.Storage.Storage
        abstract firestore: ?app: Firebase.App.App -> Firebase.Firestore.Firestore

    type CompleteFn =
        (unit -> unit)

    type [<AllowNullLiteral>] FirebaseError =
        abstract code: string with get, set
        abstract message: string with get, set
        abstract name: string with get, set
        abstract stack: string option with get, set

    type [<AllowNullLiteral>] Observer<'V, 'E> =
        abstract complete: unit -> obj option
        abstract error: error: 'E -> obj option
        abstract next: value: 'V option -> obj option

    type Unsubscribe =
        (unit -> unit)

    type [<AllowNullLiteral>] User =
        inherit Firebase.UserInfo
        abstract delete: unit -> Promise<obj option>
        abstract emailVerified: bool with get, set
        abstract getIdToken: ?forceRefresh: bool -> Promise<obj option>
        abstract getToken: ?forceRefresh: bool -> Promise<obj option>
        abstract isAnonymous: bool with get, set
        abstract linkAndRetrieveDataWithCredential: credential: Firebase.Auth.AuthCredential -> Promise<obj option>
        abstract linkWithCredential: credential: Firebase.Auth.AuthCredential -> Promise<obj option>
        abstract linkWithPhoneNumber: phoneNumber: string * applicationVerifier: Firebase.Auth.ApplicationVerifier -> Promise<obj option>
        abstract linkWithPopup: provider: Firebase.Auth.AuthProvider -> Promise<obj option>
        abstract linkWithRedirect: provider: Firebase.Auth.AuthProvider -> Promise<obj option>
        abstract metadata: Firebase.Auth.UserMetadata with get, set
        abstract phoneNumber: string option with get, set
        abstract providerData: ResizeArray<Firebase.UserInfo option> with get, set
        abstract reauthenticateAndRetrieveDataWithCredential: credential: Firebase.Auth.AuthCredential -> Promise<obj option>
        abstract reauthenticateWithCredential: credential: Firebase.Auth.AuthCredential -> Promise<obj option>
        abstract reauthenticateWithPhoneNumber: phoneNumber: string * applicationVerifier: Firebase.Auth.ApplicationVerifier -> Promise<obj option>
        abstract reauthenticateWithPopup: provider: Firebase.Auth.AuthProvider -> Promise<obj option>
        abstract reauthenticateWithRedirect: provider: Firebase.Auth.AuthProvider -> Promise<obj option>
        abstract refreshToken: string with get, set
        abstract reload: unit -> Promise<obj option>
        abstract sendEmailVerification: ?actionCodeSettings: Firebase.Auth.ActionCodeSettings option -> Promise<obj option>
        abstract toJSON: unit -> Object
        abstract unlink: providerId: string -> Promise<obj option>
        abstract updateEmail: newEmail: string -> Promise<obj option>
        abstract updatePassword: newPassword: string -> Promise<obj option>
        abstract updatePhoneNumber: phoneCredential: Firebase.Auth.AuthCredential -> Promise<obj option>
        abstract updateProfile: profile: UserUpdateProfileProfile -> Promise<obj option>

    type [<AllowNullLiteral>] UserUpdateProfileProfile =
        abstract displayName: string option with get, set
        abstract photoURL: string option with get, set

    type [<AllowNullLiteral>] UserInfo =
        abstract displayName: string option with get, set
        abstract email: string option with get, set
        abstract phoneNumber: string option with get, set
        abstract photoURL: string option with get, set
        abstract providerId: string with get, set
        abstract uid: string with get, set

    module App =

        type [<AllowNullLiteral>] App =
            abstract auth: unit -> Firebase.Auth.Auth
            abstract database: unit -> Firebase.Database.Database
            abstract delete: unit -> Promise<obj option>
            abstract messaging: unit -> Firebase.Messaging.Messaging
            abstract name: string with get, set
            abstract options: Object with get, set
            abstract storage: ?url: string -> Firebase.Storage.Storage
            abstract firestore: unit -> Firebase.Firestore.Firestore

    module Auth =

        let [<Import("Auth","firebase/auth")>] auth: Auth.IExports = jsNative

        module Auth =

            type [<AllowNullLiteral>] IExports =
                abstract Persistence: obj

            type Persistence =
                string

        type [<AllowNullLiteral>] IExports =
            abstract EmailAuthProvider: EmailAuthProviderStatic
            abstract EmailAuthProvider_Instance: EmailAuthProvider_InstanceStatic
            abstract FacebookAuthProvider: FacebookAuthProviderStatic
            abstract FacebookAuthProvider_Instance: FacebookAuthProvider_InstanceStatic
            abstract GithubAuthProvider: GithubAuthProviderStatic
            abstract GithubAuthProvider_Instance: GithubAuthProvider_InstanceStatic
            abstract GoogleAuthProvider: GoogleAuthProviderStatic
            abstract GoogleAuthProvider_Instance: GoogleAuthProvider_InstanceStatic
            abstract PhoneAuthProvider: PhoneAuthProviderStatic
            abstract PhoneAuthProvider_Instance: PhoneAuthProvider_InstanceStatic
            abstract RecaptchaVerifier: RecaptchaVerifierStatic
            abstract RecaptchaVerifier_Instance: RecaptchaVerifier_InstanceStatic
            abstract TwitterAuthProvider: TwitterAuthProviderStatic
            abstract TwitterAuthProvider_Instance: TwitterAuthProvider_InstanceStatic

        type [<AllowNullLiteral>] ActionCodeInfo =
            interface end

        type ActionCodeSettings =
            obj

        type AdditionalUserInfo =
            obj

        type [<AllowNullLiteral>] ApplicationVerifier =
            abstract ``type``: string with get, set
            abstract verify: unit -> Promise<obj option>

        type [<AllowNullLiteral>] Auth =
            abstract app: Firebase.App.App with get, set
            abstract applyActionCode: code: string -> Promise<obj option>
            abstract checkActionCode: code: string -> Promise<obj option>
            abstract confirmPasswordReset: code: string * newPassword: string -> Promise<obj option>
            abstract createUserWithEmailAndPassword: email: string * password: string -> Promise<obj option>
            abstract currentUser: Firebase.User option with get, set
            abstract fetchProvidersForEmail: email: string -> Promise<obj option>
            abstract getRedirectResult: unit -> Promise<obj option>
            abstract languageCode: string option with get, set
            abstract onAuthStateChanged: nextOrObserver: U2<Firebase.Observer<obj option, obj option>, (Firebase.User option -> obj option)> * ?error: (Firebase.Auth.Error -> obj option) * ?completed: Firebase.Unsubscribe -> Firebase.Unsubscribe
            abstract onIdTokenChanged: nextOrObserver: U2<Firebase.Observer<obj option, obj option>, (Firebase.User option -> obj option)> * ?error: (Firebase.Auth.Error -> obj option) * ?completed: Firebase.Unsubscribe -> Firebase.Unsubscribe
            abstract sendPasswordResetEmail: email: string * ?actionCodeSettings: Firebase.Auth.ActionCodeSettings option -> Promise<obj option>
            abstract setPersistence: persistence: Firebase.Auth.Auth.Persistence -> Promise<obj option>
            abstract signInAndRetrieveDataWithCredential: credential: Firebase.Auth.AuthCredential -> Promise<obj option>
            abstract signInAnonymously: unit -> Promise<obj option>
            abstract signInWithCredential: credential: Firebase.Auth.AuthCredential -> Promise<obj option>
            abstract signInWithCustomToken: token: string -> Promise<obj option>
            abstract signInWithEmailAndPassword: email: string * password: string -> Promise<obj option>
            abstract signInWithPhoneNumber: phoneNumber: string * applicationVerifier: Firebase.Auth.ApplicationVerifier -> Promise<obj option>
            abstract signInWithPopup: provider: Firebase.Auth.AuthProvider -> Promise<obj option>
            abstract signInWithRedirect: provider: Firebase.Auth.AuthProvider -> Promise<obj option>
            abstract signOut: unit -> Promise<obj option>
            abstract useDeviceLanguage: unit -> obj option
            abstract verifyPasswordResetCode: code: string -> Promise<obj option>

        type [<AllowNullLiteral>] AuthCredential =
            abstract providerId: string with get, set

        type [<AllowNullLiteral>] AuthProvider =
            abstract providerId: string with get, set

        type [<AllowNullLiteral>] ConfirmationResult =
            abstract confirm: verificationCode: string -> Promise<obj option>
            abstract verificationId: string with get, set

        type [<AllowNullLiteral>] EmailAuthProvider =
            inherit EmailAuthProvider_Instance
            abstract PROVIDER_ID: string with get, set

        type [<AllowNullLiteral>] EmailAuthProviderStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> EmailAuthProvider
            abstract credential: email: string * password: string -> Firebase.Auth.AuthCredential

        type [<AllowNullLiteral>] EmailAuthProvider_Instance =
            inherit Firebase.Auth.AuthProvider
            abstract providerId: string with get, set

        type [<AllowNullLiteral>] EmailAuthProvider_InstanceStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> EmailAuthProvider_Instance

        type [<AllowNullLiteral>] Error =
            abstract code: string with get, set
            abstract message: string with get, set

        type [<AllowNullLiteral>] FacebookAuthProvider =
            inherit FacebookAuthProvider_Instance
            abstract PROVIDER_ID: string with get, set

        type [<AllowNullLiteral>] FacebookAuthProviderStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> FacebookAuthProvider
            abstract credential: token: string -> Firebase.Auth.AuthCredential

        type [<AllowNullLiteral>] FacebookAuthProvider_Instance =
            inherit Firebase.Auth.AuthProvider
            abstract addScope: scope: string -> Firebase.Auth.AuthProvider
            abstract providerId: string with get, set
            abstract setCustomParameters: customOAuthParameters: Object -> Firebase.Auth.AuthProvider

        type [<AllowNullLiteral>] FacebookAuthProvider_InstanceStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> FacebookAuthProvider_Instance

        type [<AllowNullLiteral>] GithubAuthProvider =
            inherit GithubAuthProvider_Instance
            abstract PROVIDER_ID: string with get, set

        type [<AllowNullLiteral>] GithubAuthProviderStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> GithubAuthProvider
            abstract credential: token: string -> Firebase.Auth.AuthCredential

        type [<AllowNullLiteral>] GithubAuthProvider_Instance =
            inherit Firebase.Auth.AuthProvider
            abstract addScope: scope: string -> Firebase.Auth.AuthProvider
            abstract providerId: string with get, set
            abstract setCustomParameters: customOAuthParameters: Object -> Firebase.Auth.AuthProvider

        type [<AllowNullLiteral>] GithubAuthProvider_InstanceStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> GithubAuthProvider_Instance

        type [<AllowNullLiteral>] GoogleAuthProvider =
            inherit GoogleAuthProvider_Instance
            abstract PROVIDER_ID: string with get, set

        type [<AllowNullLiteral>] GoogleAuthProviderStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> GoogleAuthProvider
            abstract credential: ?idToken: string option * ?accessToken: string option -> Firebase.Auth.AuthCredential

        type [<AllowNullLiteral>] GoogleAuthProvider_Instance =
            inherit Firebase.Auth.AuthProvider
            abstract addScope: scope: string -> Firebase.Auth.AuthProvider
            abstract providerId: string with get, set
            abstract setCustomParameters: customOAuthParameters: Object -> Firebase.Auth.AuthProvider

        type [<AllowNullLiteral>] GoogleAuthProvider_InstanceStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> GoogleAuthProvider_Instance

        type [<AllowNullLiteral>] PhoneAuthProvider =
            inherit PhoneAuthProvider_Instance
            abstract PROVIDER_ID: string with get, set

        type [<AllowNullLiteral>] PhoneAuthProviderStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> PhoneAuthProvider
            abstract credential: verificationId: string * verificationCode: string -> Firebase.Auth.AuthCredential

        type [<AllowNullLiteral>] PhoneAuthProvider_Instance =
            inherit Firebase.Auth.AuthProvider
            abstract providerId: string with get, set
            abstract verifyPhoneNumber: phoneNumber: string * applicationVerifier: Firebase.Auth.ApplicationVerifier -> Promise<obj option>

        type [<AllowNullLiteral>] PhoneAuthProvider_InstanceStatic =
            [<Emit "new $0($1...)">] abstract Create: ?auth: Firebase.Auth.Auth option -> PhoneAuthProvider_Instance

        type [<AllowNullLiteral>] RecaptchaVerifier =
            inherit RecaptchaVerifier_Instance

        type [<AllowNullLiteral>] RecaptchaVerifierStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> RecaptchaVerifier

        type [<AllowNullLiteral>] RecaptchaVerifier_Instance =
            inherit Firebase.Auth.ApplicationVerifier
            abstract clear: unit -> obj option
            abstract render: unit -> Promise<obj option>
            abstract ``type``: string with get, set
            abstract verify: unit -> Promise<obj option>

        type [<AllowNullLiteral>] RecaptchaVerifier_InstanceStatic =
            [<Emit "new $0($1...)">] abstract Create: container: U2<obj option, string> * ?parameters: Object option * ?app: Firebase.App.App option -> RecaptchaVerifier_Instance

        type [<AllowNullLiteral>] TwitterAuthProvider =
            inherit TwitterAuthProvider_Instance
            abstract PROVIDER_ID: string with get, set

        type [<AllowNullLiteral>] TwitterAuthProviderStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> TwitterAuthProvider
            abstract credential: token: string * secret: string -> Firebase.Auth.AuthCredential

        type [<AllowNullLiteral>] TwitterAuthProvider_Instance =
            inherit Firebase.Auth.AuthProvider
            abstract providerId: string with get, set
            abstract setCustomParameters: customOAuthParameters: Object -> Firebase.Auth.AuthProvider

        type [<AllowNullLiteral>] TwitterAuthProvider_InstanceStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> TwitterAuthProvider_Instance

        type UserCredential =
            obj

        type [<AllowNullLiteral>] UserMetadata =
            abstract creationTime: string option with get, set
            abstract lastSignInTime: string option with get, set

    module Database =

        type [<AllowNullLiteral>] IExports =
            abstract enableLogging: ?logger: U2<bool, (string -> obj option)> * ?persistent: bool -> obj option

        type [<AllowNullLiteral>] DataSnapshot =
            abstract child: path: string -> Firebase.Database.DataSnapshot
            abstract exists: unit -> bool
            abstract exportVal: unit -> obj option
            abstract forEach: action: (Firebase.Database.DataSnapshot -> bool) -> bool
            abstract getPriority: unit -> U2<string, float> option
            abstract hasChild: path: string -> bool
            abstract hasChildren: unit -> bool
            abstract key: string option with get, set
            abstract numChildren: unit -> float
            abstract ``val``: unit -> obj option
            abstract ref: Firebase.Database.Reference with get, set
            abstract toJSON: unit -> Object option

        type [<AllowNullLiteral>] Database =
            abstract app: Firebase.App.App with get, set
            abstract goOffline: unit -> obj option
            abstract goOnline: unit -> obj option
            abstract ref: ?path: string -> Firebase.Database.Reference
            abstract refFromURL: url: string -> Firebase.Database.Reference

        type [<AllowNullLiteral>] OnDisconnect =
            abstract cancel: ?onComplete: (Error option -> obj option) -> Promise<obj option>
            abstract remove: ?onComplete: (Error option -> obj option) -> Promise<obj option>
            abstract set: value: obj option * ?onComplete: (Error option -> obj option) -> Promise<obj option>
            abstract setWithPriority: value: obj option * priority: U2<float, string> option * ?onComplete: (Error option -> obj option) -> Promise<obj option>
            abstract update: values: Object * ?onComplete: (Error option -> obj option) -> Promise<obj option>

        type [<AllowNullLiteral>] Query =
            abstract endAt: value: U3<float, string, bool> option * ?key: string -> Firebase.Database.Query
            abstract equalTo: value: U3<float, string, bool> option * ?key: string -> Firebase.Database.Query
            abstract isEqual: other: Firebase.Database.Query option -> bool
            abstract limitToFirst: limit: float -> Firebase.Database.Query
            abstract limitToLast: limit: float -> Firebase.Database.Query
            abstract off: ?eventType: string * ?callback: (Firebase.Database.DataSnapshot -> string option -> obj option) * ?context: Object option -> obj option
            abstract on: eventType: string * callback: (Firebase.Database.DataSnapshot option -> string -> obj option) * ?cancelCallbackOrContext: Object option * ?context: Object option -> (Firebase.Database.DataSnapshot option -> string -> obj option)
            abstract once: eventType: string * ?successCallback: (Firebase.Database.DataSnapshot -> string -> obj option) * ?failureCallbackOrContext: Object option * ?context: Object option -> Promise<obj option>
            abstract orderByChild: path: string -> Firebase.Database.Query
            abstract orderByKey: unit -> Firebase.Database.Query
            abstract orderByPriority: unit -> Firebase.Database.Query
            abstract orderByValue: unit -> Firebase.Database.Query
            abstract ref: Firebase.Database.Reference with get, set
            abstract startAt: value: U3<float, string, bool> option * ?key: string -> Firebase.Database.Query
            abstract toJSON: unit -> Object
            abstract toString: unit -> string

        type [<AllowNullLiteral>] Reference =
            inherit Firebase.Database.Query
            abstract child: path: string -> Firebase.Database.Reference
            abstract key: string option with get, set
            abstract onDisconnect: unit -> Firebase.Database.OnDisconnect
            abstract parent: Firebase.Database.Reference option with get, set
            abstract path: string with get, set
            abstract push: ?value: obj option * ?onComplete: (Error option -> obj option) -> Firebase.Database.ThenableReference
            abstract remove: ?onComplete: (Error option -> obj option) -> Promise<obj option>
            abstract root: Firebase.Database.Reference with get, set
            abstract set: value: obj option * ?onComplete: (Error option -> obj option) -> Promise<obj option>
            abstract setPriority: priority: U2<string, float> option * onComplete: (Error option -> obj option) -> Promise<obj option>
            abstract setWithPriority: newVal: obj option * newPriority: U2<string, float> option * ?onComplete: (Error option -> obj option) -> Promise<obj option>
            abstract transaction: transactionUpdate: (obj option -> obj option) * ?onComplete: (Error option -> bool -> Firebase.Database.DataSnapshot option -> obj option) * ?applyLocally: bool -> Promise<obj option>
            abstract update: values: Object * ?onComplete: (Error option -> obj option) -> Promise<obj option>

        type [<AllowNullLiteral>] ThenableReference =
            inherit Firebase.Database.Reference
            inherit PromiseLike<obj option>

    module Database =
        let [<Import("ServerValue","firebase/firebase/database")>] serverValue: ServerValue.IExports = jsNative

        module ServerValue =

            type [<AllowNullLiteral>] IExports =
                abstract TIMESTAMP: Object

    module Messaging =

        type [<AllowNullLiteral>] Messaging =
            abstract deleteToken: token: string -> Promise<obj option> option
            abstract getToken: unit -> Promise<obj option> option
            abstract onMessage: nextOrObserver: U2<Firebase.Observer<obj option, obj option>, (Object -> obj option)> -> Firebase.Unsubscribe
            abstract onTokenRefresh: nextOrObserver: U2<Firebase.Observer<obj option, obj option>, (Object -> obj option)> -> Firebase.Unsubscribe
            abstract requestPermission: unit -> Promise<obj option> option
            abstract setBackgroundMessageHandler: callback: (Object -> obj option) -> obj option
            abstract useServiceWorker: registration: obj option -> obj option

    module Storage =

        type [<AllowNullLiteral>] IExports =
            abstract StringFormat: obj
            abstract TaskEvent: obj
            abstract TaskState: obj

        type [<AllowNullLiteral>] FullMetadata =
            inherit Firebase.Storage.UploadMetadata
            abstract bucket: string with get, set
            abstract downloadURLs: ResizeArray<string> with get, set
            abstract fullPath: string with get, set
            abstract generation: string with get, set
            abstract metageneration: string with get, set
            abstract name: string with get, set
            abstract size: float with get, set
            abstract timeCreated: string with get, set
            abstract updated: string with get, set

        type [<AllowNullLiteral>] Reference =
            abstract bucket: string with get, set
            abstract child: path: string -> Firebase.Storage.Reference
            abstract delete: unit -> Promise<obj option>
            abstract fullPath: string with get, set
            abstract getDownloadURL: unit -> Promise<obj option>
            abstract getMetadata: unit -> Promise<obj option>
            abstract name: string with get, set
            abstract parent: Firebase.Storage.Reference option with get, set
            abstract put: data: obj option * ?metadata: Firebase.Storage.UploadMetadata -> Firebase.Storage.UploadTask
            abstract putString: data: string * ?format: Firebase.Storage.StringFormat * ?metadata: Firebase.Storage.UploadMetadata -> Firebase.Storage.UploadTask
            abstract root: Firebase.Storage.Reference with get, set
            abstract storage: Firebase.Storage.Storage with get, set
            abstract toString: unit -> string
            abstract updateMetadata: metadata: Firebase.Storage.SettableMetadata -> Promise<obj option>

        type [<AllowNullLiteral>] SettableMetadata =
            abstract cacheControl: string option option with get, set
            abstract contentDisposition: string option option with get, set
            abstract contentEncoding: string option option with get, set
            abstract contentLanguage: string option option with get, set
            abstract contentType: string option option with get, set
            abstract customMetadata: obj option option with get, set

        type [<AllowNullLiteral>] Storage =
            abstract app: Firebase.App.App with get, set
            abstract maxOperationRetryTime: float with get, set
            abstract maxUploadRetryTime: float with get, set
            abstract ref: ?path: string -> Firebase.Storage.Reference
            abstract refFromURL: url: string -> Firebase.Storage.Reference
            abstract setMaxOperationRetryTime: time: float -> obj option
            abstract setMaxUploadRetryTime: time: float -> obj option

        type StringFormat =
            string

        type TaskEvent =
            string

        type TaskState =
            string

        type [<AllowNullLiteral>] UploadMetadata =
            inherit Firebase.Storage.SettableMetadata
            abstract md5Hash: string option option with get, set

        type [<AllowNullLiteral>] UploadTask =
            abstract cancel: unit -> bool
            abstract catch: onRejected: (Error -> obj option) -> Promise<obj option>
            abstract on: ``event``: Firebase.Storage.TaskEvent * ?nextOrObserver: U2<Firebase.Observer<obj option, obj option>, (Object -> obj option)> option * ?error: (Error -> obj option) option * ?complete: Firebase.Unsubscribe option -> Function
            abstract pause: unit -> bool
            abstract resume: unit -> bool
            abstract snapshot: Firebase.Storage.UploadTaskSnapshot with get, set
            abstract ``then``: ?onFulfilled: (Firebase.Storage.UploadTaskSnapshot -> obj option) option * ?onRejected: (Error -> obj option) option -> Promise<obj option>

        type [<AllowNullLiteral>] UploadTaskSnapshot =
            abstract bytesTransferred: float with get, set
            abstract downloadURL: string option with get, set
            abstract metadata: Firebase.Storage.FullMetadata with get, set
            abstract ref: Firebase.Storage.Reference with get, set
            abstract state: Firebase.Storage.TaskState with get, set
            abstract task: Firebase.Storage.UploadTask with get, set
            abstract totalBytes: float with get, set

    module Firestore =

        type [<AllowNullLiteral>] IExports =
            abstract setLogLevel: logLevel: LogLevel -> unit
            abstract Firestore: FirestoreStatic
            abstract GeoPoint: GeoPointStatic
            abstract Blob: BlobStatic
            abstract Transaction: TransactionStatic
            abstract WriteBatch: WriteBatchStatic
            abstract DocumentReference: DocumentReferenceStatic
            abstract DocumentSnapshot: DocumentSnapshotStatic
            abstract QueryDocumentSnapshot: QueryDocumentSnapshotStatic
            abstract Query: QueryStatic
            abstract QuerySnapshot: QuerySnapshotStatic
            abstract CollectionReference: CollectionReferenceStatic
            abstract FieldValue: FieldValueStatic
            abstract FieldPath: FieldPathStatic

        type DocumentData =
            obj

        type UpdateData =
            obj

        /// Settings used to configure a `Firestore` instance.
        type [<AllowNullLiteral>] Settings =
            /// The hostname to connect to.
            abstract host: string option with get, set
            /// Whether to use SSL when connecting.
            abstract ssl: bool option with get, set

        type [<StringEnum>] [<RequireQualifiedAccess>] LogLevel =
            | Debug
            | Error
            | Silent

        /// `Firestore` represents a Firestore Database and is the entry point for all
        /// Firestore operations.
        type [<AllowNullLiteral>] Firestore =
            /// <summary>Specifies custom settings to be used to configure the `Firestore`
            /// instance. Must be set before invoking any other methods.</summary>
            /// <param name="settings">The settings to use.</param>
            abstract settings: settings: Settings -> unit
            /// Attempts to enable persistent storage, if possible.
            ///
            /// Must be called before any other methods (other than settings()).
            ///
            /// If this fails, enablePersistence() will reject the promise it returns.
            /// Note that even after this failure, the firestore instance will remain
            /// usable, however offline persistence will be disabled.
            ///
            /// There are several reasons why this can fail, which can be identified by
            /// the `code` on the error.
            ///
            ///    * failed-precondition: The app is already open in another browser tab.
            ///    * unimplemented: The browser is incompatible with the offline
            ///      persistence implementation.
            abstract enablePersistence: unit -> Promise<unit>
            /// <summary>Gets a `CollectionReference` instance that refers to the collection at
            /// the specified path.</summary>
            /// <param name="collectionPath">A slash-separated path to a collection.</param>
            abstract collection: collectionPath: string -> CollectionReference
            /// <summary>Gets a `DocumentReference` instance that refers to the document at the
            /// specified path.</summary>
            /// <param name="documentPath">A slash-separated path to a document.</param>
            abstract doc: documentPath: string -> DocumentReference
            /// <summary>Executes the given updateFunction and then attempts to commit the
            /// changes applied within the transaction. If any document read within the
            /// transaction has changed, the updateFunction will be retried. If it fails
            /// to commit after 5 attempts, the transaction will fail.</summary>
            /// <param name="updateFunction">The function to execute within the transaction
            /// context.</param>
            abstract runTransaction: updateFunction: (Transaction -> Promise<'T>) -> Promise<'T>
            /// Creates a write batch, used for performing multiple writes as a single
            /// atomic operation.
            abstract batch: unit -> WriteBatch
            /// The `FirebaseApp` associated with this `Firestore` instance.
            abstract app: Firebase.App.App with get, set
            /// Re-enables use of the network for this Firestore instance after a prior
            /// call to disableNetwork().
            abstract enableNetwork: unit -> Promise<unit>
            /// Disables network usage for this instance. It can be re-enabled via
            /// enableNetwork(). While the network is disabled, any snapshot listeners or
            /// get() calls will return results from cache, and any write operations will
            /// be queued until the network is restored.
            abstract disableNetwork: unit -> Promise<unit>
            abstract INTERNAL: obj with get, set

        /// `Firestore` represents a Firestore Database and is the entry point for all
        /// Firestore operations.
        type [<AllowNullLiteral>] FirestoreStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Firestore

        /// An immutable object representing a geo point in Firestore. The geo point
        /// is represented as latitude/longitude pair.
        ///
        /// Latitude values are in the range of [-90, 90].
        /// Longitude values are in the range of [-180, 180].
        type [<AllowNullLiteral>] GeoPoint =
            abstract latitude: float
            abstract longitude: float
            /// <summary>Returns true if this `GeoPoint` is equal to the provided one.</summary>
            /// <param name="other">The `GeoPoint` to compare against.</param>
            abstract isEqual: other: GeoPoint -> bool

        /// An immutable object representing a geo point in Firestore. The geo point
        /// is represented as latitude/longitude pair.
        ///
        /// Latitude values are in the range of [-90, 90].
        /// Longitude values are in the range of [-180, 180].
        type [<AllowNullLiteral>] GeoPointStatic =
            /// <summary>Creates a new immutable GeoPoint object with the provided latitude and
            /// longitude values.</summary>
            /// <param name="latitude">The latitude as number between -90 and 90.</param>
            /// <param name="longitude">The longitude as number between -180 and 180.</param>
            [<Emit "new $0($1...)">] abstract Create: latitude: float * longitude: float -> GeoPoint

        /// An immutable object representing an array of bytes.
        type [<AllowNullLiteral>] Blob =
            /// Returns the bytes of this Blob as a Base64-encoded string.
            abstract toBase64: unit -> string
            /// Returns the bytes of this Blob in a new Uint8Array.
            abstract toUint8Array: unit -> Uint8Array
            /// <summary>Returns true if this `Blob` is equal to the provided one.</summary>
            /// <param name="other">The `Blob` to compare against.</param>
            abstract isEqual: other: Blob -> bool

        /// An immutable object representing an array of bytes.
        type [<AllowNullLiteral>] BlobStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Blob
            /// Creates a new Blob from the given Base64 string, converting it to
            /// bytes.
            abstract fromBase64String: base64: string -> Blob
            /// Creates a new Blob from the given Uint8Array.
            abstract fromUint8Array: array: Uint8Array -> Blob

        /// A reference to a transaction.
        /// The `Transaction` object passed to a transaction's updateFunction provides
        /// the methods to read and write data within the transaction context. See
        /// `Firestore.runTransaction()`.
        type [<AllowNullLiteral>] Transaction =
            /// <summary>Reads the document referenced by the provided `DocumentReference.`</summary>
            /// <param name="documentRef">A reference to the document to be read.</param>
            abstract get: documentRef: DocumentReference -> Promise<DocumentSnapshot>
            /// <summary>Writes to the document referred to by the provided `DocumentReference`.
            /// If the document does not exist yet, it will be created. If you pass
            /// `SetOptions`, the provided data can be merged into the existing document.</summary>
            /// <param name="documentRef">A reference to the document to be set.</param>
            /// <param name="data">An object of the fields and values for the document.</param>
            /// <param name="options">An object to configure the set behavior.</param>
            abstract set: documentRef: DocumentReference * data: DocumentData * ?options: SetOptions -> Transaction
            /// <summary>Updates fields in the document referred to by the provided
            /// `DocumentReference`. The update will fail if applied to a document that
            /// does not exist.</summary>
            /// <param name="documentRef">A reference to the document to be updated.</param>
            /// <param name="data">An object containing the fields and values with which to
            /// update the document. Fields can contain dots to reference nested fields
            /// within the document.</param>
            abstract update: documentRef: DocumentReference * data: UpdateData -> Transaction
            /// <summary>Updates fields in the document referred to by the provided
            /// `DocumentReference`. The update will fail if applied to a document that
            /// does not exist.
            ///
            /// Nested fields can be updated by providing dot-separated field path
            /// strings or by providing FieldPath objects.</summary>
            /// <param name="documentRef">A reference to the document to be updated.</param>
            /// <param name="field">The first field to update.</param>
            /// <param name="value">The first value.</param>
            /// <param name="moreFieldsAndValues">Additional key/value pairs.</param>
            abstract update: documentRef: DocumentReference * field: U2<string, FieldPath> * value: obj option * [<ParamArray>] moreFieldsAndValues: ResizeArray<obj option> -> Transaction
            /// <summary>Deletes the document referred to by the provided `DocumentReference`.</summary>
            /// <param name="documentRef">A reference to the document to be deleted.</param>
            abstract delete: documentRef: DocumentReference -> Transaction

        /// A reference to a transaction.
        /// The `Transaction` object passed to a transaction's updateFunction provides
        /// the methods to read and write data within the transaction context. See
        /// `Firestore.runTransaction()`.
        type [<AllowNullLiteral>] TransactionStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Transaction

        /// A write batch, used to perform multiple writes as a single atomic unit.
        ///
        /// A `WriteBatch` object can be acquired by calling `Firestore.batch()`. It
        /// provides methods for adding writes to the write batch. None of the
        /// writes will be committed (or visible locally) until `WriteBatch.commit()`
        /// is called.
        ///
        /// Unlike transactions, write batches are persisted offline and therefore are
        /// preferable when you don't need to condition your writes on read data.
        type [<AllowNullLiteral>] WriteBatch =
            /// <summary>Writes to the document referred to by the provided `DocumentReference`.
            /// If the document does not exist yet, it will be created. If you pass
            /// `SetOptions`, the provided data can be merged into the existing document.</summary>
            /// <param name="documentRef">A reference to the document to be set.</param>
            /// <param name="data">An object of the fields and values for the document.</param>
            /// <param name="options">An object to configure the set behavior.</param>
            abstract set: documentRef: DocumentReference * data: DocumentData * ?options: SetOptions -> WriteBatch
            /// <summary>Updates fields in the document referred to by the provided
            /// `DocumentReference`. The update will fail if applied to a document that
            /// does not exist.</summary>
            /// <param name="documentRef">A reference to the document to be updated.</param>
            /// <param name="data">An object containing the fields and values with which to
            /// update the document. Fields can contain dots to reference nested fields
            /// within the document.</param>
            abstract update: documentRef: DocumentReference * data: UpdateData -> WriteBatch
            /// <summary>Updates fields in the document referred to by this `DocumentReference`.
            /// The update will fail if applied to a document that does not exist.
            ///
            /// Nested fields can be update by providing dot-separated field path strings
            /// or by providing FieldPath objects.</summary>
            /// <param name="documentRef">A reference to the document to be updated.</param>
            /// <param name="field">The first field to update.</param>
            /// <param name="value">The first value.</param>
            /// <param name="moreFieldsAndValues">Additional key value pairs.</param>
            abstract update: documentRef: DocumentReference * field: U2<string, FieldPath> * value: obj option * [<ParamArray>] moreFieldsAndValues: ResizeArray<obj option> -> WriteBatch
            /// <summary>Deletes the document referred to by the provided `DocumentReference`.</summary>
            /// <param name="documentRef">A reference to the document to be deleted.</param>
            abstract delete: documentRef: DocumentReference -> WriteBatch
            /// Commits all of the writes in this write batch as a single atomic unit.
            abstract commit: unit -> Promise<unit>

        /// A write batch, used to perform multiple writes as a single atomic unit.
        ///
        /// A `WriteBatch` object can be acquired by calling `Firestore.batch()`. It
        /// provides methods for adding writes to the write batch. None of the
        /// writes will be committed (or visible locally) until `WriteBatch.commit()`
        /// is called.
        ///
        /// Unlike transactions, write batches are persisted offline and therefore are
        /// preferable when you don't need to condition your writes on read data.
        type [<AllowNullLiteral>] WriteBatchStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> WriteBatch

        /// Options for use with `DocumentReference.onSnapshot()` to control the
        /// behavior of the snapshot listener.
        type [<AllowNullLiteral>] DocumentListenOptions =
            /// Raise an event even if only metadata of the document changed. Default is
            /// false.
            abstract includeMetadataChanges: bool option

        /// An options object that configures the behavior of `set()` calls in
        /// `DocumentReference`, `WriteBatch` and `Transaction`. These calls can be
        /// configured to perform granular merges instead of overwriting the target
        /// documents in their entirety by providing a `SetOptions` with `merge: true`.
        type [<AllowNullLiteral>] SetOptions =
            /// Changes the behavior of a set() call to only replace the values specified
            /// in its data argument. Fields omitted from the set() call remain
            /// untouched.
            abstract merge: bool option

        /// A `DocumentReference` refers to a document location in a Firestore database
        /// and can be used to write, read, or listen to the location. The document at
        /// the referenced location may or may not exist. A `DocumentReference` can
        /// also be used to create a `CollectionReference` to a subcollection.
        type [<AllowNullLiteral>] DocumentReference =
            /// The identifier of the document within its collection.
            abstract id: string
            /// The `Firestore` for the Firestore database (useful for performing
            /// transactions, etc.).
            abstract firestore: Firestore
            /// A reference to the Collection to which this DocumentReference belongs.
            abstract parent: CollectionReference
            /// A string representing the path of the referenced document (relative
            /// to the root of the database).
            abstract path: string
            /// <summary>Gets a `CollectionReference` instance that refers to the collection at
            /// the specified path.</summary>
            /// <param name="collectionPath">A slash-separated path to a collection.</param>
            abstract collection: collectionPath: string -> CollectionReference
            /// <summary>Returns true if this `DocumentReference` is equal to the provided one.</summary>
            /// <param name="other">The `DocumentReference` to compare against.</param>
            abstract isEqual: other: DocumentReference -> bool
            /// <summary>Writes to the document referred to by this `DocumentReference`. If the
            /// document does not yet exist, it will be created. If you pass
            /// `SetOptions`, the provided data can be merged into an existing document.</summary>
            /// <param name="data">A map of the fields and values for the document.</param>
            /// <param name="options">An object to configure the set behavior.</param>
            abstract set: data: DocumentData * ?options: SetOptions -> Promise<unit>
            /// <summary>Updates fields in the document referred to by this `DocumentReference`.
            /// The update will fail if applied to a document that does not exist.</summary>
            /// <param name="data">An object containing the fields and values with which to
            /// update the document. Fields can contain dots to reference nested fields
            /// within the document.</param>
            abstract update: data: UpdateData -> Promise<unit>
            /// <summary>Updates fields in the document referred to by this `DocumentReference`.
            /// The update will fail if applied to a document that does not exist.
            ///
            /// Nested fields can be updated by providing dot-separated field path
            /// strings or by providing FieldPath objects.</summary>
            /// <param name="field">The first field to update.</param>
            /// <param name="value">The first value.</param>
            /// <param name="moreFieldsAndValues">Additional key value pairs.</param>
            abstract update: field: U2<string, FieldPath> * value: obj option * [<ParamArray>] moreFieldsAndValues: ResizeArray<obj option> -> Promise<unit>
            /// Deletes the document referred to by this `DocumentReference`.
            abstract delete: unit -> Promise<unit>
            /// Reads the document referred to by this `DocumentReference`.
            ///
            /// Note: get() attempts to provide up-to-date data when possible by waiting
            /// for data from the server, but it may return cached data or fail if you
            /// are offline and the server cannot be reached.
            abstract get: unit -> Promise<DocumentSnapshot>
            /// <summary>Attaches a listener for DocumentSnapshot events. You may either pass
            /// individual `onNext` and `onError` callbacks or pass a single observer
            /// object with `next` and `error` callbacks.
            ///
            /// NOTE: Although an `onCompletion` callback can be provided, it will
            /// never be called because the snapshot stream is never-ending.</summary>
            /// <param name="observer">A single object containing `next` and `error` callbacks.</param>
            abstract onSnapshot: observer: DocumentReferenceOnSnapshotObserver -> (unit -> unit)
            abstract onSnapshot: options: DocumentListenOptions * observer: DocumentReferenceOnSnapshotObserver_ -> (unit -> unit)
            abstract onSnapshot: onNext: (DocumentSnapshot -> unit) * ?onError: (Error -> unit) * ?onCompletion: (unit -> unit) -> (unit -> unit)
            abstract onSnapshot: options: DocumentListenOptions * onNext: (DocumentSnapshot -> unit) * ?onError: (Error -> unit) * ?onCompletion: (unit -> unit) -> (unit -> unit)

        type [<AllowNullLiteral>] DocumentReferenceOnSnapshotObserver =
            abstract next: (DocumentSnapshot -> unit) option with get, set
            abstract error: (FirestoreError -> unit) option with get, set
            abstract complete: (unit -> unit) option with get, set

        type [<AllowNullLiteral>] DocumentReferenceOnSnapshotObserver_ =
            abstract next: (DocumentSnapshot -> unit) option with get, set
            abstract error: (Error -> unit) option with get, set
            abstract complete: (unit -> unit) option with get, set

        /// A `DocumentReference` refers to a document location in a Firestore database
        /// and can be used to write, read, or listen to the location. The document at
        /// the referenced location may or may not exist. A `DocumentReference` can
        /// also be used to create a `CollectionReference` to a subcollection.
        type [<AllowNullLiteral>] DocumentReferenceStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> DocumentReference

        /// Options that configure how data is retrieved from a `DocumentSnapshot`
        /// (e.g. the desired behavior for server timestamps that have not yet been set
        /// to their final value).
        type [<AllowNullLiteral>] SnapshotOptions =
            /// If set, controls the return value for server timestamps that have not yet
            /// been set to their final value.
            ///
            /// By specifying 'estimate', pending server timestamps return an estimate
            /// based on the local clock. This estimate will differ from the final value
            /// and cause these values to change once the server result becomes available.
            ///
            /// By specifying 'previous', pending timestamps will be ignored and return
            /// their previous value instead.
            ///
            /// If omitted or set to 'none', `null` will be returned by default until the
            /// server value becomes available.
            abstract serverTimestamps: U3<string, string, string> option

        /// Metadata about a snapshot, describing the state of the snapshot.
        type [<AllowNullLiteral>] SnapshotMetadata =
            /// True if the snapshot contains the result of local writes (e.g. set() or
            /// update() calls) that have not yet been committed to the backend.
            /// If your listener has opted into metadata updates (via
            /// `DocumentListenOptions` or `QueryListenOptions`) you will receive another
            /// snapshot with `hasPendingWrites` equal to false once the writes have been
            /// committed to the backend.
            abstract hasPendingWrites: bool
            /// True if the snapshot was created from cached data rather than
            /// guaranteed up-to-date server data. If your listener has opted into
            /// metadata updates (via `DocumentListenOptions` or `QueryListenOptions`)
            /// you will receive another snapshot with `fromCache` equal to false once
            /// the client has received up-to-date data from the backend.
            abstract fromCache: bool
            /// <summary>Returns true if this `SnapshotMetadata` is equal to the provided one.</summary>
            /// <param name="other">The `SnapshotMetadata` to compare against.</param>
            abstract isEqual: other: SnapshotMetadata -> bool

        /// A `DocumentSnapshot` contains data read from a document in your Firestore
        /// database. The data can be extracted with `.data()` or `.get(<field>)` to
        /// get a specific field.
        ///
        /// For a `DocumentSnapshot` that points to a non-existing document, any data
        /// access will return 'undefined'. You can use the `exists` property to
        /// explicitly verify a document's existence.
        type [<AllowNullLiteral>] DocumentSnapshot =
            /// True if the document exists.
            abstract exists: bool
            /// A `DocumentReference` to the document location.
            abstract ref: DocumentReference
            /// The ID of the document for which this `DocumentSnapshot` contains data.
            abstract id: string
            /// Metadata about this snapshot, concerning its source and if it has local
            /// modifications.
            abstract metadata: SnapshotMetadata
            /// <summary>Retrieves all fields in the document as an Object. Returns 'undefined' if
            /// the document doesn't exist.
            ///
            /// By default, `FieldValue.serverTimestamp()` values that have not yet been
            /// set to their final value will be returned as `null`. You can override
            /// this by passing an options object.</summary>
            /// <param name="options">An options object to configure how data is retrieved from
            /// the snapshot (e.g. the desired behavior for server timestamps that have
            /// not yet been set to their final value).</param>
            abstract data: ?options: SnapshotOptions -> DocumentData option
            /// <summary>Retrieves the field specified by `fieldPath`. Returns 'undefined' if the
            /// document or field doesn't exist.
            ///
            /// By default, a `FieldValue.serverTimestamp()` that has not yet been set to
            /// its final value will be returned as `null`. You can override this by
            /// passing an options object.</summary>
            /// <param name="fieldPath">The path (e.g. 'foo' or 'foo.bar') to a specific field.</param>
            /// <param name="options">An options object to configure how the field is retrieved
            /// from the snapshot (e.g. the desired behavior for server timestamps that have
            /// not yet been set to their final value).</param>
            abstract get: fieldPath: U2<string, FieldPath> * ?options: SnapshotOptions -> obj option
            /// <summary>Returns true if this `DocumentSnapshot` is equal to the provided one.</summary>
            /// <param name="other">The `DocumentSnapshot` to compare against.</param>
            abstract isEqual: other: DocumentSnapshot -> bool

        /// A `DocumentSnapshot` contains data read from a document in your Firestore
        /// database. The data can be extracted with `.data()` or `.get(<field>)` to
        /// get a specific field.
        ///
        /// For a `DocumentSnapshot` that points to a non-existing document, any data
        /// access will return 'undefined'. You can use the `exists` property to
        /// explicitly verify a document's existence.
        type [<AllowNullLiteral>] DocumentSnapshotStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> DocumentSnapshot

        /// A `QueryDocumentSnapshot` contains data read from a document in your
        /// Firestore database as part of a query. The document is guaranteed to exist
        /// and its data can be extracted with `.data()` or `.get(<field>)` to get a
        /// specific field.
        ///
        /// A `QueryDocumentSnapshot` offers the same API surface as a
        /// `DocumentSnapshot`. Since query results contain only existing documents, the
        /// `exists` property will always be true and `data()` will never return
        /// 'undefined'.
        type [<AllowNullLiteral>] QueryDocumentSnapshot =
            inherit DocumentSnapshot
            /// <summary>Retrieves all fields in the document as an Object.
            ///
            /// By default, `FieldValue.serverTimestamp()` values that have not yet been
            /// set to their final value will be returned as `null`. You can override
            /// this by passing an options object.</summary>
            /// <param name="options">An options object to configure how data is retrieved from
            /// the snapshot (e.g. the desired behavior for server timestamps that have
            /// not yet been set to their final value).</param>
            abstract data: ?options: SnapshotOptions -> DocumentData

        /// A `QueryDocumentSnapshot` contains data read from a document in your
        /// Firestore database as part of a query. The document is guaranteed to exist
        /// and its data can be extracted with `.data()` or `.get(<field>)` to get a
        /// specific field.
        ///
        /// A `QueryDocumentSnapshot` offers the same API surface as a
        /// `DocumentSnapshot`. Since query results contain only existing documents, the
        /// `exists` property will always be true and `data()` will never return
        /// 'undefined'.
        type [<AllowNullLiteral>] QueryDocumentSnapshotStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> QueryDocumentSnapshot

        type [<StringEnum>] [<RequireQualifiedAccess>] OrderByDirection =
            | Desc
            | Asc

        type [<StringEnum>] [<RequireQualifiedAccess>] WhereFilterOp =
            // Changed by me
            // | <
            // | <=
            // | ==
            // | >=
            // | >
            | L
            | LEQ
            | EQ
            | GEQ
            | G

        /// Options for use with `Query.onSnapshot() to control the behavior of the
        /// snapshot listener.
        type [<AllowNullLiteral>] QueryListenOptions =
            /// Raise an event even if only metadata changes (i.e. one of the
            /// `QuerySnapshot.metadata` properties). Default is false.
            abstract includeQueryMetadataChanges: bool option
            /// Raise an event even if only metadata of a document in the query results
            /// changes (i.e. one of the `DocumentSnapshot.metadata` properties on one of
            /// the documents). Default is false.
            abstract includeDocumentMetadataChanges: bool option

        /// A `Query` refers to a Query which you can read or listen to. You can also
        /// construct refined `Query` objects by adding filters and ordering.
        type [<AllowNullLiteral>] Query =
            /// The `Firestore` for the Firestore database (useful for performing
            /// transactions, etc.).
            abstract firestore: Firestore
            /// <summary>Creates and returns a new Query with the additional filter that documents
            /// must contain the specified field and the value should satisfy the
            /// relation constraint provided.</summary>
            /// <param name="fieldPath">The path to compare</param>
            /// <param name="opStr">The operation string (e.g "<", "<=", "==", ">", ">=").</param>
            /// <param name="value">The value for comparison</param>
            abstract where: fieldPath: U2<string, FieldPath> * opStr: WhereFilterOp * value: obj option -> Query
            /// <summary>Creates and returns a new Query that's additionally sorted by the
            /// specified field, optionally in descending order instead of ascending.</summary>
            /// <param name="fieldPath">The field to sort by.</param>
            /// <param name="directionStr">Optional direction to sort by ('asc' or 'desc'). If
            /// not specified, order will be ascending.</param>
            abstract orderBy: fieldPath: U2<string, FieldPath> * ?directionStr: OrderByDirection -> Query
            /// <summary>Creates and returns a new Query that's additionally limited to only
            /// return up to the specified number of documents.</summary>
            /// <param name="limit">The maximum number of items to return.</param>
            abstract limit: limit: float -> Query
            /// <summary>Creates and returns a new Query that starts at the provided document
            /// (inclusive). The starting position is relative to the order of the query.
            /// The document must contain all of the fields provided in the orderBy of
            /// this query.</summary>
            /// <param name="snapshot">The snapshot of the document to start at.</param>
            abstract startAt: snapshot: DocumentSnapshot -> Query
            /// <summary>Creates and returns a new Query that starts at the provided fields
            /// relative to the order of the query. The order of the field values
            /// must match the order of the order by clauses of the query.</summary>
            /// <param name="fieldValues">The field values to start this query at, in order
            /// of the query's order by.</param>
            abstract startAt: [<ParamArray>] fieldValues: ResizeArray<obj option> -> Query
            /// <summary>Creates and returns a new Query that starts after the provided document
            /// (exclusive). The starting position is relative to the order of the query.
            /// The document must contain all of the fields provided in the orderBy of
            /// this query.</summary>
            /// <param name="snapshot">The snapshot of the document to start after.</param>
            abstract startAfter: snapshot: DocumentSnapshot -> Query
            /// <summary>Creates and returns a new Query that starts after the provided fields
            /// relative to the order of the query. The order of the field values
            /// must match the order of the order by clauses of the query.</summary>
            /// <param name="fieldValues">The field values to start this query after, in order
            /// of the query's order by.</param>
            abstract startAfter: [<ParamArray>] fieldValues: ResizeArray<obj option> -> Query
            /// <summary>Creates and returns a new Query that ends before the provided document
            /// (exclusive). The end position is relative to the order of the query. The
            /// document must contain all of the fields provided in the orderBy of this
            /// query.</summary>
            /// <param name="snapshot">The snapshot of the document to end before.</param>
            abstract endBefore: snapshot: DocumentSnapshot -> Query
            /// <summary>Creates and returns a new Query that ends before the provided fields
            /// relative to the order of the query. The order of the field values
            /// must match the order of the order by clauses of the query.</summary>
            /// <param name="fieldValues">The field values to end this query before, in order
            /// of the query's order by.</param>
            abstract endBefore: [<ParamArray>] fieldValues: ResizeArray<obj option> -> Query
            /// <summary>Creates and returns a new Query that ends at the provided document
            /// (inclusive). The end position is relative to the order of the query. The
            /// document must contain all of the fields provided in the orderBy of this
            /// query.</summary>
            /// <param name="snapshot">The snapshot of the document to end at.</param>
            abstract endAt: snapshot: DocumentSnapshot -> Query
            /// <summary>Creates and returns a new Query that ends at the provided fields
            /// relative to the order of the query. The order of the field values
            /// must match the order of the order by clauses of the query.</summary>
            /// <param name="fieldValues">The field values to end this query at, in order
            /// of the query's order by.</param>
            abstract endAt: [<ParamArray>] fieldValues: ResizeArray<obj option> -> Query
            /// <summary>Returns true if this `Query` is equal to the provided one.</summary>
            /// <param name="other">The `Query` to compare against.</param>
            abstract isEqual: other: Query -> bool
            /// Executes the query and returns the results as a QuerySnapshot.
            abstract get: unit -> Promise<QuerySnapshot>
            /// <summary>Attaches a listener for QuerySnapshot events. You may either pass
            /// individual `onNext` and `onError` callbacks or pass a single observer
            /// object with `next` and `error` callbacks.
            ///
            /// NOTE: Although an `onCompletion` callback can be provided, it will
            /// never be called because the snapshot stream is never-ending.</summary>
            /// <param name="observer">A single object containing `next` and `error` callbacks.</param>
            abstract onSnapshot: observer: QueryOnSnapshotObserver -> (unit -> unit)
            abstract onSnapshot: options: QueryListenOptions * observer: QueryOnSnapshotObserver_ -> (unit -> unit)
            abstract onSnapshot: onNext: (QuerySnapshot -> unit) * ?onError: (Error -> unit) * ?onCompletion: (unit -> unit) -> (unit -> unit)
            abstract onSnapshot: options: QueryListenOptions * onNext: (QuerySnapshot -> unit) * ?onError: (Error -> unit) * ?onCompletion: (unit -> unit) -> (unit -> unit)

        type [<AllowNullLiteral>] QueryOnSnapshotObserver =
            abstract next: (QuerySnapshot -> unit) option with get, set
            abstract error: (Error -> unit) option with get, set
            abstract complete: (unit -> unit) option with get, set

        type [<AllowNullLiteral>] QueryOnSnapshotObserver_ =
            abstract next: (QuerySnapshot -> unit) option with get, set
            abstract error: (Error -> unit) option with get, set
            abstract complete: (unit -> unit) option with get, set

        /// A `Query` refers to a Query which you can read or listen to. You can also
        /// construct refined `Query` objects by adding filters and ordering.
        type [<AllowNullLiteral>] QueryStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Query

        /// A `QuerySnapshot` contains zero or more `DocumentSnapshot` objects
        /// representing the results of a query. The documents can be accessed as an
        /// array via the `docs` property or enumerated using the `forEach` method. The
        /// number of documents can be determined via the `empty` and `size`
        /// properties.
        type [<AllowNullLiteral>] QuerySnapshot =
            /// The query on which you called `get` or `onSnapshot` in order to get this
            /// `QuerySnapshot`.
            abstract query: Query
            /// Metadata about this snapshot, concerning its source and if it has local
            /// modifications.
            abstract metadata: SnapshotMetadata
            /// An array of the documents that changed since the last snapshot. If this
            /// is the first snapshot, all documents will be in the list as added
            /// changes.
            abstract docChanges: ResizeArray<DocumentChange>
            /// An array of all the documents in the QuerySnapshot.
            abstract docs: ResizeArray<QueryDocumentSnapshot>
            /// The number of documents in the QuerySnapshot.
            abstract size: float
            /// True if there are no documents in the QuerySnapshot.
            abstract empty: bool
            /// <summary>Enumerates all of the documents in the QuerySnapshot.</summary>
            /// <param name="callback">A callback to be called with a `QueryDocumentSnapshot` for
            /// each document in the snapshot.</param>
            /// <param name="thisArg">The `this` binding for the callback.</param>
            abstract forEach: callback: (QueryDocumentSnapshot -> unit) * ?thisArg: obj option -> unit
            /// <summary>Returns true if this `QuerySnapshot` is equal to the provided one.</summary>
            /// <param name="other">The `QuerySnapshot` to compare against.</param>
            abstract isEqual: other: QuerySnapshot -> bool

        /// A `QuerySnapshot` contains zero or more `DocumentSnapshot` objects
        /// representing the results of a query. The documents can be accessed as an
        /// array via the `docs` property or enumerated using the `forEach` method. The
        /// number of documents can be determined via the `empty` and `size`
        /// properties.
        type [<AllowNullLiteral>] QuerySnapshotStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> QuerySnapshot

        type [<StringEnum>] [<RequireQualifiedAccess>] DocumentChangeType =
            | Added
            | Removed
            | Modified

        /// A `DocumentChange` represents a change to the documents matching a query.
        /// It contains the document affected and the type of change that occurred.
        type [<AllowNullLiteral>] DocumentChange =
            /// The type of change ('added', 'modified', or 'removed').
            abstract ``type``: DocumentChangeType
            /// The document affected by this change.
            abstract doc: QueryDocumentSnapshot
            /// The index of the changed document in the result set immediately prior to
            /// this DocumentChange (i.e. supposing that all prior DocumentChange objects
            /// have been applied). Is -1 for 'added' events.
            abstract oldIndex: float
            /// The index of the changed document in the result set immediately after
            /// this DocumentChange (i.e. supposing that all prior DocumentChange
            /// objects and the current DocumentChange object have been applied).
            /// Is -1 for 'removed' events.
            abstract newIndex: float

        /// A `CollectionReference` object can be used for adding documents, getting
        /// document references, and querying for documents (using the methods
        /// inherited from `Query`).
        type [<AllowNullLiteral>] CollectionReference =
            inherit Query
            /// The identifier of the collection.
            abstract id: string
            /// A reference to the containing Document if this is a subcollection, else
            /// null.
            abstract parent: DocumentReference option
            /// A string representing the path of the referenced collection (relative
            /// to the root of the database).
            abstract path: string
            /// <summary>Get a `DocumentReference` for the document within the collection at the
            /// specified path. If no path is specified, an automatically-generated
            /// unique ID will be used for the returned DocumentReference.</summary>
            /// <param name="documentPath">A slash-separated path to a document.</param>
            abstract doc: ?documentPath: string -> DocumentReference
            /// <summary>Add a new document to this collection with the specified data, assigning
            /// it a document ID automatically.</summary>
            /// <param name="data">An Object containing the data for the new document.</param>
            abstract add: data: DocumentData -> Promise<DocumentReference>
            /// <summary>Returns true if this `CollectionReference` is equal to the provided one.</summary>
            /// <param name="other">The `CollectionReference` to compare against.</param>
            abstract isEqual: other: CollectionReference -> bool

        /// A `CollectionReference` object can be used for adding documents, getting
        /// document references, and querying for documents (using the methods
        /// inherited from `Query`).
        type [<AllowNullLiteral>] CollectionReferenceStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> CollectionReference

        /// Sentinel values that can be used when writing document fields with set()
        /// or update().
        type [<AllowNullLiteral>] FieldValue =
            /// <summary>Returns true if this `FieldValue` is equal to the provided one.</summary>
            /// <param name="other">The `FieldValue` to compare against.</param>
            abstract isEqual: other: FieldValue -> bool

        /// Sentinel values that can be used when writing document fields with set()
        /// or update().
        type [<AllowNullLiteral>] FieldValueStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> FieldValue
            /// Returns a sentinel used with set() or update() to include a
            /// server-generated timestamp in the written data.
            abstract serverTimestamp: unit -> FieldValue
            /// Returns a sentinel for use with update() to mark a field for deletion.
            abstract delete: unit -> FieldValue

        /// A FieldPath refers to a field in a document. The path may consist of a
        /// single field name (referring to a top-level field in the document), or a
        /// list of field names (referring to a nested field in the document).
        type [<AllowNullLiteral>] FieldPath =
            /// <summary>Returns true if this `FieldPath` is equal to the provided one.</summary>
            /// <param name="other">The `FieldPath` to compare against.</param>
            abstract isEqual: other: FieldPath -> bool

        /// A FieldPath refers to a field in a document. The path may consist of a
        /// single field name (referring to a top-level field in the document), or a
        /// list of field names (referring to a nested field in the document).
        type [<AllowNullLiteral>] FieldPathStatic =
            /// <summary>Creates a FieldPath from the provided field names. If more than one field
            /// name is provided, the path will point to a nested field in a document.</summary>
            /// <param name="fieldNames">A list of field names.</param>
            [<Emit "new $0($1...)">] abstract Create: [<ParamArray>] fieldNames: ResizeArray<string> -> FieldPath
            /// Returns a special sentinel FieldPath to refer to the ID of a document.
            /// It can be used in queries to sort or filter by the document ID.
            abstract documentId: unit -> FieldPath

        type [<StringEnum>] [<RequireQualifiedAccess>] FirestoreErrorCode =
            | Cancelled
            | Unknown
            | [<CompiledName "invalid-argument">] InvalidArgument
            | [<CompiledName "deadline-exceeded">] DeadlineExceeded
            | [<CompiledName "not-found">] NotFound
            | [<CompiledName "already-exists">] AlreadyExists
            | [<CompiledName "permission-denied">] PermissionDenied
            | [<CompiledName "resource-exhausted">] ResourceExhausted
            | [<CompiledName "failed-precondition">] FailedPrecondition
            | Aborted
            | [<CompiledName "out-of-range">] OutOfRange
            | Unimplemented
            | Internal
            | Unavailable
            | [<CompiledName "data-loss">] DataLoss
            | Unauthenticated

        /// An error returned by a Firestore operation.
        type [<AllowNullLiteral>] FirestoreError =
            abstract code: FirestoreErrorCode with get, set
            abstract message: string with get, set
            abstract name: string with get, set
            abstract stack: string option with get, set
