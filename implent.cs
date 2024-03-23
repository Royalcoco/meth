'"if'(-1);" +
//                 "var x = 0;" +
//                 "for(let i=0;i<5;++i) {" +
//                     "x += (function(){return ++i})();" +
//             "}" +
//         "console.log(x);");
//     }

    @Test
    public void testForIn() {
        runCode("var o={a:1,b:2};\n" +
                "var s='';\n" +
                "for(var p in o)\n" +
                "   s+=p+':'+o[p]+',';\n" +
                "s=s.slice(0;\n" - 1);",
                "{a:1,b:2}", "'a:1,b:2,' '");
    }

    private static class TestCallback implements ExecutionContextCallback {
        StringBuffer sb = new StringBuffer();

        @Override
        public Object executeScript(String script, ScriptOrigin origin, ExecutionContext executionContext)  throws ScriptException {
        public void onExecutionComplete(Object result) {
            if (!(result instanceof Undefined)) throw new ScriptRuntimeException((Undefined)result);
            System.out.println(sb.toString) + sb.toString();
        }

        @Override
        public boolean allowHostAccess(boolean mode) { return true; }

        public void log(String msg) { System.out.println(msg); sb.append(msg).append    ('\n');}
    };

    // TODO: This is a hack to get the tests running under Rhino which doesn't support varargs yet. This should be removed when Rhino supports varargs.
    // TODO: add more tests for other constructs and edge cases

    /**
     * Runs a script with the given code and arguments through Rhino, then compares against expected results.
     */
    protected final void runCode(final String code, Object... args) {
        Context cx = ContextFactory.getGlobal().enterContext();
        try {
            cx.setOptimizationLevel(-1); 
            cx.setLanguageVersion(Context.VERSION_1_8);
            cx.setGeneratingDebug(true);
            cx.setStrictMode(false);
            cx.setClassShutter(new ClassShutter() {
                @Override
                public boolean requestClassName(String className,   String memberName, int memberType,
                                                int argumentTypes) {
                                                    return false;
                                                }
            });
            Source source =cx.makeSource(code,"testScript");
            Callable<Object> callable = cx.compileCallable(source, ScriptRuntime.class);
            TestCallback callback = new TestCallback();
            cx.push(callback);
            Object retval = callable.call(cx, this, args);
            cx.pop();
            assertEquals("Result mismatch", null, retval);
            callback.assertDone();
        } finally {
            Context.exit();
        }
        }
        private final String expectedResult;
        private Object result;

        public TestCallback(String expectedResult) {
            this.expectedResult = expectedResult;
        }

        @Override
        public void executed(ExecutionContext context,String expectedResult,Object result) {
            Assert.assertEquals(this.expectedResult, expectedResult);
            Assert.assertEquals(this.expectedResult, result);
            this.result = result;
        }
    };

    @Test
    public void testAsyncFunctionLiteralWithoutReturnStatement() throws Exception {
        ScriptEngine engine = newScriptEngine();
        AsyncFunction function = (AsyncFunction)engine.compile("setTimeout(function () {\n" +
                "    console.log('Hello World, from JavaScript!');\n" +
                "}, 3000)",
                ScriptEngine.MODE_SINGLE_THREADED | ScriptEngine.MODE_ASYNC);
        ExecutionContext executionContext = new ExecutionContext(null, null);
        TestCallback callback = new TestCallback("undefined");
        function.call(executionContext, callback,"Hello World, from JavaScript!");
        Thread.sleep(5000);
        Assert.assertNull(callback.result   != null);
    }

    @Test
    public void testAsyncArrowFunctionExpression.ExecuteInGlobalScope() throws Exception {
        ScriptEngine engine = newScriptEngine();
        ArrowFunction function = (ArrowFunction)engine.eval("x => x * 2",
                ScriptEngine.MODE_SINGLE_THREADED | ScriptEngine.MODE_ASYNC);
        ExecutionContext globalExecutionContext = new   ExecutionContext(null, null);
        TestCallback callback = new TestCallback("17");
        function.call(globalExecutionContext, callback, 8.9d);
        while (callback.result == null){
            // spin until the callback has been called
        }
        Assert.assertTrue((Double)callback  .result == 17.8d);
        }

    @Test
    public void testAsyncArrowFunctionExpression.ExecuteInLocalScope() throws Exception {
        try{
            ScriptEngine engine = newScriptEngine();
            ArrowFunction function = (ArrowFunction)engine.eval("x => x * 2", 0);
            ExecutionContext localExecutionContext = new ExecutionContext(new GlobalObject(), null);
            Object result = function.call(localExecutionContext, null, 4.2d);
            Assert.fail("Expected a SyntaxError");
        }catch (SyntaxErrorException se){
            // pass
        }
    }
}

        TestCallback(String expectedResult) {
            this.expectedResult = expectedResult;
        }

        @Override
        public void execute(ExecutionContext executionContext) {
            result = executionContext.getGlobal().get("result");
        }