using System;
using Windows.UI.Xaml.Controls;
using ReactNative.UIManager;
using ReactNative.UIManager.Annotations;
using ReactNative.UIManager.Events;
using Newtonsoft.Json.Linq;
using Windows.UI.Xaml;
using System.Globalization;

namespace ReactNative.Views.DatePicker
{
    /// <summary>
    /// A view manager responsible for rendering a DatePicker.
    /// </summary>
    public class ReactDatePickerManager : BaseViewManager<Windows.UI.Xaml.Controls.DatePicker, ReactDatePickerShadowNode>
    {
        /// <summary>
        /// The name of the view manager.
        /// </summary>
        public override string Name
        {
            get
            {
                return "DatePickerWindows";
            }
        }

        /// <summary>
        /// Sets the value of the picker.
        /// </summary>
        /// <param name="view">The picker view element.</param>
        /// <param name="date">The new value.</param>
        [ReactProp("date")]
        public void SetDate(Windows.UI.Xaml.Controls.DatePicker view, DateTime? date)
        {
            if (date.HasValue)
            {
                view.Date = date.Value;
            }
        }

        /// <summary>
        /// Sets the maximum allowed year of the picker.
        /// </summary>
        /// <param name="view">The picker view element.</param>
        /// <param name="date">The value to set as maximum.</param>
        [ReactProp("maxYear")]
        public void SetMaxYear(Windows.UI.Xaml.Controls.DatePicker view, DateTime? date)
        {
            if (date.HasValue)
            {
                view.MaxYear = date.Value;
            }
        }

        /// <summary>
        /// Sets the minimum allowed year of the picker.
        /// </summary>
        /// <param name="view">The picker view element.</param>
        /// <param name="date">The value to set as minimum.</param>
        [ReactProp("minYear")]
        public void SetMinYear(Windows.UI.Xaml.Controls.DatePicker view, DateTime? date)
        {
            if (date.HasValue)
            {
                view.MinYear = date.Value;
            }
        }

        /// <summary>
        /// Sets the date picker header text
        /// </summary>
        /// <param name="view"></param>
        /// <param name="header">The title of the header</param>
        [ReactProp("header")]
        public void SetHeader(Windows.UI.Xaml.Controls.DatePicker view, String header)
        {
            view.Header = header;
        }

        /// <summary>
        /// Sets the date picker current and min height
        /// </summary>
        /// <param name="view"></param>
        /// <param name="height"></param>
        [ReactProp(ViewProps.Height)]
        public void SetHeight(Windows.UI.Xaml.Controls.DatePicker view, double height)
        {
            view.MinHeight = height;
            view.MaxHeight = height;
            view.Height = height;
        }

        /// <summary>
        /// Sets the date picker current and min width
        /// </summary>
        /// <param name="view"></param>
        /// <param name="width"></param>
        [ReactProp(ViewProps.Width)]
        public void SetWidth(Windows.UI.Xaml.Controls.DatePicker view, double width)
        {
            view.Width = width;
            view.MinWidth = width;
            view.MaxWidth = width;
        }

        /// <summary>
        /// This method returns the <see cref="ReactDatePickerShadowNode"/>
        /// which will be then used for measuring the position and size of the
        /// view.
        /// </summary>
        /// <returns>The shadow node instance.</returns>
        public override ReactDatePickerShadowNode CreateShadowNodeInstance()
        {
            return new ReactDatePickerShadowNode();
        }

        /// <summary>
        /// Implement this method to receive optional extra data enqueued from
        /// the corresponding instance of <see cref="ReactShadowNode"/> in
        /// <see cref="ReactShadowNode.OnCollectExtraUpdates"/>.
        /// </summary>
        /// <param name="root">The root view.</param>
        /// <param name="extraData">The extra data.</param>
        public override void UpdateExtraData(Windows.UI.Xaml.Controls.DatePicker root, object extraData)
        {
        }

        /// <summary>
        /// Unbind event handlers.
        /// </summary>
        /// <param name="reactContext">The React context.</param>
        /// <param name="view">The view.</param>
        public override void OnDropViewInstance(ThemedReactContext reactContext, Windows.UI.Xaml.Controls.DatePicker view)
        {
            base.OnDropViewInstance(reactContext, view);
            view.DateChanged -= OnDateChanged;
            view.PointerReleased -= onPointerReleased;
            view.PointerPressed -= onPointerReleased;
        }

        /// <summary>
        /// Creates a new view instance of type <see cref="Windows.UI.Xaml.Controls.DatePicker"/>.
        /// </summary>
        /// <param name="reactContext">The React context.</param>
        /// <returns>The view instance.</returns>
        protected override Windows.UI.Xaml.Controls.DatePicker CreateViewInstance(ThemedReactContext reactContext)
        {
            Windows.UI.Xaml.Controls.DatePicker picker = new Windows.UI.Xaml.Controls.DatePicker();
            return picker;
        }

        /// <summary>
        /// Binds the <see cref="Windows.UI.Xaml.Controls.DatePicker.DateChanged"/> event to a handler.
        /// </summary>
        /// <param name="reactContext">The react context</param>
        /// <param name="view">The view instance</param>
        protected override void AddEventEmitters(ThemedReactContext reactContext, Windows.UI.Xaml.Controls.DatePicker view)
        {
            base.AddEventEmitters(reactContext, view);
            view.DateChanged += OnDateChanged;
            view.PointerReleased += onPointerReleased;
            view.PointerPressed += onPointerReleased;
        }

        /// <summary>
        /// Date changed update handler.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event.</param>
        private void OnDateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            var datePicker = (Windows.UI.Xaml.Controls.DatePicker)sender;
            DateTime newDate = e.NewDate.DateTime;

            datePicker.GetReactContext().GetNativeModule<UIManagerModule>()
                .EventDispatcher
                .DispatchEvent(new ReactDatePickerEvent(datePicker.GetTag(), newDate));
        }
        /// <summary>
        /// DatePicker release event
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event.</param>
        private void onPointerReleased(object sender, RoutedEventArgs e)
        {
            //Does not work at this time 
            //var datePicker = (Windows.UI.Xaml.Controls.DatePicker)sender;
        }

        /// <summary>
        /// A DatePicker-specific event to communicate with JavaScript.
        /// </summary>
        class ReactDatePickerEvent : Event
        {
            private readonly DateTime _date;
            /// <summary>
            /// Creates an instance of the event.
            /// </summary>
            /// <param name="viewTag">The viewtag of the instantiating view.</param>
            /// <param name="date">Date to include in the event payload.</param>
            public ReactDatePickerEvent(int viewTag, DateTime date) : base(viewTag)
            {
                _date = date;
            }

            /// <summary>
            /// Internal name of the event.
            /// </summary>
            public override string EventName
            {
                get
                {
                    return "topChange";
                }
            }

            /// <summary>
            /// Dispatches the event through the JavaScript bridge.
            /// </summary>
            /// <param name="eventEmitter"></param>
            public override void Dispatch(RCTEventEmitter eventEmitter)
            {
                JObject eventData = new JObject
                {
                    {"date", _date },
                };
                eventEmitter.receiveEvent(ViewTag, EventName, eventData);
            }
        }
    }
}