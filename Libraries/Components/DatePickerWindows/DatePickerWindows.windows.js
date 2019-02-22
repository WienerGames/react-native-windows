/**
 * @providesModule DatePickerWindows
 * @flow
 */
'use strict';
import { View } from 'react-native'

var PropTypes = require('prop-types');
var React = require('React');
var ReactNative = require('ReactNative');
var UIManager = require('UIManager');
var ViewPropTypes = require('ViewPropTypes');

var requireNativeComponent = require('requireNativeComponent');

var DATEPICKER_REF = 'datePicker';

/**
 * React component that wraps the Windows-only `DatePicker`.
 */
class DatePickerWindows extends React.Component {
  props: {
    date?: Date;
  }
  static propTypes = {
    ...ViewPropTypes,
    /**
     * The currently selected date.
     */
    date: PropTypes.instanceOf(Date),
    /**
     * Date change handler.
     *
     * This is called when the user changes the date or time in the UI.
     * The first and only argument is a Date object representing the new
     * date.
     */
    onChange: PropTypes.func,

    /**
     * Minimum year.
     *
     * Restricts the range with an lower bound on the year.
     */
    minYear: PropTypes.instanceOf(Date),

    /**
     * Maximum year.
     *
     * Restricts the range with an upper bound on the year.
     */
    maxYear: PropTypes.instanceOf(Date),


    /**
     * Header title.
     *
     * Sets a title for the picker header component.
     */
    header: PropTypes.string,

    /**
     * Component height
     *
     * Sets the date picker prefered height
     */
    height: PropTypes.number,

    /**
     * Component visability
     *
     * Sets the component visability
     */
    isVisible: PropTypes.bool,

    /**
     * Chage date on scroll
     *
     * Handles date changes on date change scroll
     */
    dateChangeScroll: PropTypes.func,

    /**
     * Open calendar programatically
     *
     */
    isOpen: PropTypes.bool

  };

  static defaultProps = {
    date: new Date(),
    header: '',
    isVisible: true,
    isOpen: false
  }

  _dateChangeScroll = (event) => {
    this.props.dateChangeScroll && this.props.dateChangeScroll(new Date(event.nativeEvent.date));
  }

  _onChange = (event) => {
    this.props.onChange && this.props.onChange(new Date(event.nativeEvent.date));
  }

  render() {
    return (
      <View pointerEvents={this.props.isVisible ? 'auto' : 'none'}
        style={{ opacity: this.props.isVisible ? 1 : 0 }}>
        <NativeWindowsDatePicker
          ref={DATEPICKER_REF}
          isOpen={this.props.isOpen}
          style={this.props.style}
          date={this.props.date}
          minYear={this.props.minYear}
          maxYear={this.props.maxYear}
          onChange={this._onChange}
          dateChangeScroll={this._dateChangeScroll}
          header={this.props.header}
          height={this.props.height}
          width={this.props.width}
        />
      </View>
    )
  }

}

var NativeWindowsDatePicker = requireNativeComponent('DatePickerWindows', DatePickerWindows);

module.exports = DatePickerWindows;