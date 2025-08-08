<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Cadmium.Layout.Header" %>

<header class="flex justify-between items-center py-6 px-8 bg-stone-900 text-stone-100">
    <div class="flex flex-col gap-1">
        <span class="flex items-center gap-1">
            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-flame-icon lucide-flame"><path d="M8.5 14.5A2.5 2.5 0 0 0 11 12c0-1.38-.5-2-1-3-1.072-2.143-.224-4.054 2-6 .5 2.5 2 4.9 4 6.5 2 1.6 3 3.5 3 5.5a7 7 0 1 1-14 0c0-1.153.433-2.294 1-3a2.5 2.5 0 0 0 2.5 2.5z"/></svg>
            <h1 class="m-0 text-2xl">Cadmium Application</h1>
        </span>
        <nav class="flex gap-4 text-sm">
            <a href="/" class="text-stone-300 no-underline">Home</a>
            <a href="/" class="text-stone-300 no-underline">About Us</a>
            <a href="/" class="text-stone-300 no-underline">Contact Us</a>
        </nav>
    </div>
    <div>
        <button class="px-4 py-2 bg-stone-100">Hello</button>
    </div>
</header>