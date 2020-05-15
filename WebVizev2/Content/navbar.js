$(function() {
  'use strict';
  
  function toggle(e) {
    if (e) e.preventDefault();
    
    var $this = $(this),
        $navbar = $this.parents('.navbar'),
        $item = $this.parent();
    
    $('.nav-item.active', $navbar).removeClass('active');
    $item.addClass('active');
    
    if ($navbar.hasClass('main-nav')) {
      $('.active', $navbar.siblings('.sub-nav')).removeClass('active');
      $($item.data('target')).addClass('active');
    }
  }
  
  function leave(e) {
    var $this = $(this),
        $navbar = $this.siblings('.main-nav'),
        $subnav = $('.navbar-nav.active', $this);
    
    $('[data-target="#' + $subnav.attr('id') + '"]', $navbar).removeClass('hover');
    $subnav.removeClass('active');
  };
  
  function enter(e) {
    var $this = $(this),
        $navbar = $this.parents('.navbar');
    
    $('.nav-item.hover', $navbar).removeClass('hover');
    $this.addClass('hover');
    
    if ($navbar.hasClass('main-nav')) {
      $('.active', $navbar.siblings('.sub-nav')).removeClass('active');
      $($this.data('target')).addClass('active');
    }
  }
  
  $('.main-nav .nav-link, .sub-nav .nav-link').click(toggle);
  $('.main-nav .nav-item').mouseenter(enter);
  $('.sub-nav').mouseleave(leave);
});